using System;

namespace Park.Data
{
    public class Transaction
    {
        public readonly DateTime CreationTime = DateTime.Now;

        public Guid CarId { get; }

        public double MoneyDrawned { get; }

        public Transaction(Guid carId, double moneyDrawned)
        {
            CarId = carId;
            MoneyDrawned = moneyDrawned;
        }

        public override string ToString()
        {
            try
            {
                return $"{CreationTime.ToString("G")}" +
                       $" Money operation: {MoneyDrawned} Car id: {Parking.Instance.GetCarById(CarId).Type}";
            }
            catch (NullReferenceException)
            {
                return $"{CreationTime.ToString("G")}" +
                       $" Money operation: {MoneyDrawned}";
            }
        }
    }
}