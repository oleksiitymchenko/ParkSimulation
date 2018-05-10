using Park.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            x.AddCar(new Car(20, CarType.Bus));
            x.AddCar(new Car(20, CarType.Truck));
            x.AddCar(new Car(20, CarType.Passenger));
            x.AddCar(new Car(20, CarType.Motorcycle));


            Console.WriteLine("LOL");
            Console.WriteLine("LOL");
            Console.WriteLine("LOL");
            Console.ReadLine();
        }
    }
}
