using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data
{
    public class Parking
    {
        private static readonly Lazy<Parking> _instanse = new Lazy<Parking>(() => new Parking());

        public static Parking Instance
        {
            get
                {return _instanse.Value;}
        }
        private Parking(){ }

        private List<Car> _cars = new List<Car>();
        private List<Transaction> _transactions = new List<Transaction>();
        private double Balance = 0;
    }
}
