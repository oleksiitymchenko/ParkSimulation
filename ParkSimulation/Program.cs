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
            x.AddCar(new Car(200, CarType.Truck));
            x.AddCar(new Car(200, CarType.Passenger));
            x.AddCar(new Car(200, CarType.Motorcycle));
            x.AddCar(new Car(200, CarType.Motorcycle));
            x.AddCar(i);


            Console.WriteLine(DateTime.Now.ToString("F"));
            Console.WriteLine("LOL");
            Parking.Instance.ShowAllTransactions();
            Thread.Sleep(1000);
            Console.WriteLine(Parking.Instance.FreeSpace);
            x.RemoveCar(i);
            x.RemoveCar(i);
            Console.WriteLine(Parking.Instance.FreeSpace);



            Thread.Sleep(10000);

              
                Thread.Sleep(60500);
                Console.WriteLine("===========================");
                Parking.Instance.ShowAllTransactions();
                Console.WriteLine(  "******************************************");
                foreach (var item in Parking.Instance.OneMinuteTransactions){
                    Console.WriteLine(item);
                }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(Parking.Instance.Balance);
               

            

            Console.WriteLine("LOL");
            Console.ReadLine();
        }
    }
}
