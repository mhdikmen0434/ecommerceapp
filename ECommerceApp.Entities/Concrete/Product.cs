using System.Collections.Generic;
using ECommerceApp.Core.Entities;

namespace ECommerceApp.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public string ImageLocation{ get; set; }
        public decimal Price{ get; set; }
        public virtual  Cart Cart{ get; set; }

    }
}
