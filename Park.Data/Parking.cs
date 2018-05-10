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

        private Parking() { }

        private List<Car> _cars = new List<Car>();
        private List<Transaction> _transactions = new List<Transaction>();
        public List<Car> Cars => _cars;
        public List<Transaction> Transactions => _transactions;
        public double Balance { get; private set; }

       // private delegate void WithdrawnMoney(ref Car car, ref List<Transaction> TransactionList);

      //  private event WithdrawnMoney withdrawn;

       // private static Timer _CarTimer = new Timer(Settings.Timeout * 1000);
        private TimerCallback TimerDelegate;
        private Timer TimerItem;
        static Parking()
        {
            //_CarTimer.Start();
             
        
        }

        public void ShowTransactions

        public void AddCar(Car car)
        {
            TimerDelegate = new TimerCallback(TimerWithdraw);
            _cars.Add(car);
            TimerItem = new Timer(TimerDelegate, new Kostil(_cars, _transactions), 0, Settings.Timeout*100);
        }

        public void RemoveCar(Car car)
        {
            if (car.Fine == 0)
            {
                _cars.Remove(car);
                TimerItem = new Timer(TimerDelegate, new Kostil(_cars, _transactions), 0, Settings.Timeout * 100);
            }
            else
            {
                throw new Exception("Fine is imposed on your car. Put money on car`s account");
            }
        }

  

        public void WithdrawFromCar( Car car, List<Transaction> TransactionList)
        {
            
            if (car.AccountBalance - Settings.ParkingPrices[car.Type] < 0 )
            {
                if (car.Fine==0)
                {
                    car.Fine = Settings.Fine * Settings.ParkingPrices[car.Type];
                    TransactionList.Add(new Transaction(car.Id, 0 - car.Fine));
                   // Console.WriteLine($"Fine{car.Fine} , {car.Type}, {car.AccountBalance}");
                }
            }
            else
            {
                car.AccountBalance -= Settings.ParkingPrices[car.Type];
                TransactionList.Add(new Transaction(car.Id, 0-Settings.ParkingPrices[car.Type]));
              //  Console.WriteLine($"Withdrawn {car.AccountBalance}, {car.Type}, {car.Fine}");
            }
          
        }

        private void TimerWithdraw(object kostil)
        {
            Kostil data = (Kostil)kostil;
            for (int i = 0; i < data.CarReferences.Count; i++)
            {
                WithdrawFromCar(data.CarReferences[i], data.TransactionReferences);
            }
           
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
