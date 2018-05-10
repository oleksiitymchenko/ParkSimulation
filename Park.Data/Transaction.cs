using System;
using System.Collections.Generic;

namespace Park.Data
{
    public class Transaction
    {
        public DateTime CreationTime { get; private set; }


        public Guid CarId { get; private set; }

        public double MoneyDrawned { get; private set; }

        public Transaction(Guid CarId, double MoneyDrawned)
        {
            this.CarId = CarId;
            this.MoneyDrawned = MoneyDrawned;
            this.CreationTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{CreationTime.Date}:{CreationTime.Hour}:" +
                $"{CreationTime.Minute}:{CreationTime.Second}" +
                $" Money operation: {MoneyDrawned} Car id: {CarId}";
        }
    }
}