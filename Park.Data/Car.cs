using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data
{
    public class Car
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        
        public double AccountBalance { get; private set; }

        public CarType Type { get; private set; }

        public double Fine { get; set; } = 0;

        public Car(double AccountBalance,
            CarType type)
        {
            this.AccountBalance = AccountBalance;
            this.Type = type;
        }

        public void Withdraw()
        {
            if (AccountBalance - Settings.ParkingPrices[this.Type] < 0)
            {
                Fine = Settings.Fine * Settings.ParkingPrices[this.Type];
            }
            else
            {
                AccountBalance -= Settings.ParkingPrices[this.Type];
            }
            Console.WriteLine($"Withdrawn {AccountBalance}, {Type}, {Fine}");
        }
    }
    
    public enum CarType
    {
        Passenger,
        Truck,
        Bus,
        Motorcycle
    }
}
