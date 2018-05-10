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
           // Console.ReadLine();

            var x = Parking.Instance;
            var i = new Car(20, CarType.Bus);
            x.AddCar(i);
            x.AddCar(new Car(20, CarType.Truck));
            x.AddCar(new Car(20, CarType.Passenger));
            x.AddCar(new Car(20, CarType.Motorcycle));
            x.AddCar(new Car(20, CarType.Motorcycle));



            Console.WriteLine(DateTime.Now.ToString("F"));
            Console.WriteLine("LOL");
            Thread.Sleep(1000);
            //  x.RemoveCar(i);
            Parking.Instance.ShowTransactions();
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Console.WriteLine("===========================");
            x.RemoveCar(i);
            Parking.Instance.ShowTransactions();
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Console.WriteLine("===========================");
            Parking.Instance.ShowTransactions();
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Console.WriteLine("===========================");
            Parking.Instance.ShowTransactions();
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Console.WriteLine("===========================");
            Parking.Instance.ShowTransactions();
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Console.WriteLine("===========================");
            Parking.Instance.ShowTransactions();
            Console.WriteLine("LOL");
            Console.ReadLine();
        }
    }
}
