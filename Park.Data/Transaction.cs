using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data
{
    class Transaction
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
    }
}
