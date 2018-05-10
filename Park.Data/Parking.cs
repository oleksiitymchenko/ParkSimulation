using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
namespace Park.Data
{
    public class Parking
    {
        private static readonly Lazy<Parking> _instanse = new Lazy<Parking>(() => new Parking());
        

        public static Parking Instance => _instanse.Value;

        private Parking() {
            TimerDelegate = new TimerCallback(TimerWithdraw);
            TimerItem = new Timer(TimerDelegate, new Kostil(_cars, _transactions), 0, Settings.Timeout * 1000);
        }


        private  List<Car> _cars = new List<Car>();
        private  List<Transaction> _transactions = new List<Transaction>();
        public  List<Car> Cars => _cars;
        public List<Transaction> Transactions => _transactions;
        public double Balance { get; private set; }
        private TimerCallback TimerDelegate;
        private Timer TimerItem;
      
        public void ShowTransactions()
        {
            Transaction[] list = new Transaction[Transactions.Count];
            Transactions.CopyTo(list);
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public void RemoveCar(Car car)
        {
            if (car.Fine == 0)
            {
                _cars.Remove(car);
                TimerItem.Dispose();
                TimerItem = new Timer(TimerDelegate, new Kostil(_cars, _transactions), 0, Settings.Timeout * 1000);
            }
            else
            {
                throw new Exception("Fine is imposed on your car. Put money on car`s account");
            }
        }

        

        public void WithdrawFromCar( List<Car> list, List<Transaction> TransactionList)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AccountBalance - Settings.ParkingPrices[list[i].Type] < 0)
                {
                    if (list[i].Fine == 0)
                    {
                        list[i].Fine = Settings.Fine * Settings.ParkingPrices[list[i].Type];
                        var trans = new Transaction(list[i].Id, 0 - list[i].Fine);
                        TransactionList.Add(trans);
                        // Console.WriteLine($"Fine{car.Fine} , {car.Type}, {car.AccountBalance}");
                        // Console.WriteLine(trans);
                    }
                }
                else
                {
                    list[i].AccountBalance -= Settings.ParkingPrices[list[i].Type];
                    var trans = new Transaction(list[i].Id, 0 - Settings.ParkingPrices[list[i].Type]);
                    TransactionList.Add(trans);
                    // Console.WriteLine($"Withdrawn {car.AccountBalance}, {car.Type}, {car.Fine}");
                    // Console.WriteLine(trans);
                }
            }
            
          
        }

        private  void TimerWithdraw(object kostil)
        {
            Kostil data = (Kostil)kostil;
            WithdrawFromCar(data.CarReferences, data.TransactionReferences);
        }

        
       private class Kostil
        {
            public List<Car> CarReferences;
            public List<Transaction> TransactionReferences;

            public Kostil( List<Car> car, 
                 List<Transaction> transactions)
            {
                CarReferences = car;
                TransactionReferences = transactions;
            }
        }
    }
}
