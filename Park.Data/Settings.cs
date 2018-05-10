using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data
{
    public static class Settings
    {
        public static int Timeout { get; set; } = 3;

        public static Dictionary<CarType, int> ParkingPrices { get; set; } = new Dictionary<CarType, int>
        { [CarType.Motorcycle] = 1, [CarType.Bus]=2, [CarType.Passenger] = 3, [CarType.Truck]=4};

        public static int ParkingSpace { get; set; } = 100;

        public static double fine { get; set; } = 0.8;
    }
}
