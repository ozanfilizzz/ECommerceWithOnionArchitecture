using Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Concrete
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int UnitInStock { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
