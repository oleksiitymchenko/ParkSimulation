using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;

namespace Park.Data
{
    public class Parking
    {
        private static readonly Lazy<Parking> Instanse = new Lazy<Parking>(() => new Parking());

        public static Parking Instance => Instanse.Value;

        private TimerCallback _timerCallback;
        private Timer _timerItem;
      

        private Parking()
        {
            _timerCallback = TimerWithdraw;
            _timerItem = new Timer(_timerCallback, new Kostil(_cars, _transactions), 0, Settings.Timeout * 1000);
        }


        private List<Car> _cars = new List<Car>();
        private List<Transaction> _transactions = new List<Transaction>();
        public List<Transaction> Transactions => _transactions;

        public double Balance { get; private set; }
        public int FreeSpace { get; private set; } = Settings.ParkingSpace;
       

        public void ShowAllTransactions()
        {

            for (int i = 0; i < Transactions.Count; i++)
            {
                Console.WriteLine(Transactions[i].ToString());
            }
        }

        public List<Transaction> OneMinuteTransactions
        {   
            get
            {
                var transList = new List<Transaction>();
                for (int i = 0; i < Transactions.Count; i++)
                {
                    if (Transactions[i].CreationTime.CompareTo(DateTime.Now.AddMinutes(-1))>=0)
                    {
                        transList.Add(Transactions[i]);
                    }
                }

                return transList;
            }
        }


        public void AddCar(Car car)
        {
                _cars.Add(car);
                 FreeSpace -= 1;
        }

        public void RemoveCar(Car car)
        {
            if (car.Fine == 0)
            {
                _cars.Remove(car);
                FreeSpace += 1;
            }
            else
            {
                throw new Exception("Fine is imposed on your car. Put money on car`s account");
            }
        }


        public void WithdrawFromCar(List<Car> list, List<Transaction> transactionList)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AccountBalance - Settings.ParkingPrices[list[i].Type] < 0)
                {
                    if (list[i].Fine == 0)
                    {
                        list[i].Fine = Settings.Fine * Settings.ParkingPrices[list[i].Type];
                        var trans = new Transaction(list[i].Id, 0 - list[i].Fine);
                        Balance += Math.Abs(trans.MoneyDrawned);
                        transactionList.Add(trans);
                    }
                    else return;
                }
                else
                {
                    list[i].AccountBalance -= Settings.ParkingPrices[list[i].Type];
                    var trans = new Transaction(list[i].Id, 0 - Settings.ParkingPrices[list[i].Type]);
                    Balance += Math.Abs(trans.MoneyDrawned);
                    transactionList.Add(trans);
                }
            }
        }

       

        public Car GetCarById(Guid id)
        {
            foreach (Car car in _cars)
            {
                if (car.Id==id)
                {
                    return car;
                }
            }
            return null;
        }
        private void TimerWithdraw(object kostil)
        {
            Kostil data = (Kostil)kostil;
            WithdrawFromCar(data.CarReferences, data.TransactionReferences);
     
        }
        private class Kostil
        {
            internal List<Car> CarReferences;
            internal List<Transaction> TransactionReferences;

            public Kostil(List<Car> car,
                List<Transaction> transactions)
            {
                CarReferences = car;
                TransactionReferences = transactions;
            }
            
        }
    }
}