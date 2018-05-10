using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data
{
    class Car
    {
        public Guid Id { get; private set; }
        
        public double AccountBalance { get; private set; }

        public CarType Type { get; private set; }

        public Car(double AccountBalance,
            CarType type)
        {
            this.AccountBalance = AccountBalance;
            this.Type = type;
            this.Id = Guid.NewGuid();
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
