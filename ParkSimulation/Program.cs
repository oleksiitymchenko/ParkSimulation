using Park.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ParkSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Settings.ParkingSpace);
            Settings.ParkingSpace = 200;
            Console.WriteLine(Settings.ParkingSpace);
            Console.ReadLine();

            var x = Parking.Instance;
            var i = new Car(20, CarType.Bus);
            x.AddCar(i);
            x.AddCar(new Car(20, CarType.Truck));
            x.AddCar(new Car(20, CarType.Passenger));
            x.AddCar(new Car(20, CarType.Motorcycle));
           

            Console.WriteLine("LOL");
            Console.WriteLine("LOL");
            Thread.Sleep(10000);
            //  x.RemoveCar(i);
            foreach (var item in Parking.Instance.Transactions)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("LOL");
            Console.ReadLine();
        }
    }
}
