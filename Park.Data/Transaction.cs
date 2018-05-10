using System;
using System.Collections.Generic;

namespace Park.Data
{
    public class Transaction
    {
        public readonly DateTime CreationTime = DateTime.Now;

        public Guid CarId { get; private set; }

        public double MoneyDrawned { get; private set; }

        public Transaction(Guid CarId, double MoneyDrawned)
        {
            this.CarId = CarId;
            this.MoneyDrawned = MoneyDrawned;
            
        }

        public override string ToString()
        {
            return $"{CreationTime.ToString("G")}"+
                $" Money operation: {MoneyDrawned} Car id: {CarId}";
        }
    }
}