using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Entities;

namespace ECommerceApp.Entities.Dtos
{
    public class CartDtoForPage : IDto
    {
        public List<CartDto> Cart { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
