using Park.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
