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
                       $" Operation: {MoneyDrawned} Car type: {Parking.Instance.GetCarById(CarId).Type}";
            }
            catch (NullReferenceException)
            {
                return $"{CreationTime.ToString("G")}" +
                       $" Operation: {MoneyDrawned} Car is removed from parking";
            }
        }
    }
}