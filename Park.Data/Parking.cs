using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Park.Data
{
    public class Parking
    {
        private static readonly Lazy<Parking> _instanse = new Lazy<Parking>(() => new Parking());

        public static Parking Instance => _instanse.Value;

        private Parking() { }

        private List<Car> _cars = new List<Car>();
        public double Balance { get; private set; }

        private List<Transaction> _transactions = new List<Transaction>();

        private static Timer _timer = new Timer(Settings.Timeout * 1000);

        static Parking()
        {
            _timer.Start();
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
            _timer.Elapsed += (Object source, ElapsedEventArgs e) => { car.Withdraw(); };
        }
        

        public void RemoveCar(Car car)
        {
            if (car.Fine==0)
            {
                _cars.Remove(car);
            }
        }
    }
}
