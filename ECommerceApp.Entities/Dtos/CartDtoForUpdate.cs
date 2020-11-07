using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Entities;

namespace ECommerceApp.Entities.Dtos
{
    public class CartDtoForUpdate : IDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
