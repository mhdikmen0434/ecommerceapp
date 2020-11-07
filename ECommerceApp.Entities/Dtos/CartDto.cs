using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Entities;

namespace ECommerceApp.Entities.Dtos
{
    public class CartDto : IDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool QuantityEqualsStock { get; set; }
        public decimal ProductTotalPrice { get; set; }
    }
}
