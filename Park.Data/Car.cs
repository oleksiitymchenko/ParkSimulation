using System;

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

        public override string ToString()
        {
            return $"Car type: {Type}, Account balance: {AccountBalance}, Fine: {Fine}, Id: {Id}";
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
