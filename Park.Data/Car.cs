using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Timers;

namespace Park.Data
{
    public class Car
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        
        public double AccountBalance { get;  set; }

        public CarType Type { get; private set; }

        public double Fine { get;  set; } = 0;

        public Car(double AccountBalance,
            CarType type)
        {
            this.AccountBalance = AccountBalance;
            this.Type = type;
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
