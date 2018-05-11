using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace Park.Data
{
    public class Parking
    {
        private static readonly Lazy<Parking> Instanse = new Lazy<Parking>(() => new Parking());

        public static Parking Instance => Instanse.Value;

        private readonly int _timercounter;
  
        private Timer _timerItem;
      
        private Parking()
        {
            TimerCallback timerCallback = TimerWithdraw;
            _timerItem = new Timer(timerCallback, new TimerPayload(Cars, Transactions, ref _timercounter), 0, Settings.Timeout * 1000);
        }

        public List<Car> Cars { get; } = new List<Car>();

        public List<Transaction> Transactions { get; } = new List<Transaction>();

        public double Balance { get; private set; } 

        public int FreeSpace { get; private set; } = Settings.ParkingSpace;

        public void AddCar(Car car)
        {
                Cars.Add(car);
                FreeSpace -= 1;
        }

        public void RemoveCar(Car car)
        {
            if (car.Fine == 0.0 || !(car.AccountBalance<=0))
            {
                Cars.Remove(car);
                FreeSpace += 1;
            }
            else
            {
                throw new FormatException("Fine is imposed on your car. Put money on car`s account");
            }
        }

        public void Deposit(Car car,double sum)
        {
            if (sum >= 0)
            {
                car.AccountBalance += sum; 
                Transactions.Add(new Transaction(car.Id,0+sum));
            }
        }

        private void WithdrawFromCar(List<Car> list, List<Transaction> transactionList)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].AccountBalance - Settings.ParkingPrices[list[i].Type] < 0)
                {
                    if (list[i].Fine == 0.0)
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
            foreach (Car car in Cars)
            {
                if (car.Id==id)
                {
                    return car;
                }
            }
            return null;
        }

        public List<Transaction> TransactionsOneMinute
        {
            get
            {
                var transList = new List<Transaction>();
                for (int i = 0; i < Transactions.Count; i++)
                {
                    if (Transactions[i].CreationTime.CompareTo(DateTime.Now.AddMinutes(-1)) >= 0)
                    {
                        transList.Add(Transactions[i]);
                    }
                }

                return transList;
            }
        }

        public string TransactionsLogged()
        {
            try
            {
                using (StreamReader sw = new StreamReader(Settings.LogPath, true))
                {
                    return sw.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "File is not found";
            }

        }

        private void LogMinuteTransactions(List<Transaction> list)
        {
            double sum = 0;
            foreach (Transaction trans in list)
            {
                sum += Math.Abs(trans.MoneyDrawned);
            }
           
                using (StreamWriter sw = new StreamWriter(Settings.LogPath,true))
                {
                    sw.WriteLine($"Date: {DateTime.Today.ToString("d")}; Earned money: {sum}");
                }   
        }

        private void TimerWithdraw(object payload)
        {
            TimerPayload data = (TimerPayload)payload;
            WithdrawFromCar(data.CarReferences, data.TransactionReferences);
          
            for(int i =0; i<data.TransactionReferences.Count;i++)
            {
                if (data.TransactionReferences[i].CreationTime.CompareTo(DateTime.Now.AddMinutes(-2))<=0)
                {
                    data.TransactionReferences.Remove(data.TransactionReferences[i]);
                }
            }

            ++data.Counter;
            if (data.Counter * Settings.Timeout * 1000 >= 60000)
            {
                LogMinuteTransactions(TransactionsOneMinute);
                data.Counter = 0;
            }
        }

        private sealed class TimerPayload
        {
            internal List<Car> CarReferences;
            internal List<Transaction> TransactionReferences;
            internal int Counter;
            public TimerPayload(List<Car> car,
                List<Transaction> transactions,
                ref int counter)
            {
                CarReferences = car;
                TransactionReferences = transactions;
                Counter = counter;
            }
            
        }
    }
}