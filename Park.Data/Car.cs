using System;

namespace Park.Data
{
    public class Car
    {
        public Guid Id { get; } = Guid.NewGuid();

        public double AccountBalance { get; set; }

        public CarType Type { get; }

        public double Fine { get; set; } = 0;

        public Car(double accountBalance,
            CarType type)
        {
            AccountBalance = accountBalance;
            Type = type;
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