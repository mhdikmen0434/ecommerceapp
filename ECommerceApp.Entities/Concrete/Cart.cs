using System.ComponentModel.DataAnnotations.Schema;
using ECommerceApp.Core.Entities;

namespace ECommerceApp.Entities.Concrete
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
}
}
