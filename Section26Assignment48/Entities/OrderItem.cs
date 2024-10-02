using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderItem
    {
        [Key]
        public Guid OrderItemId { get; set; }

        [Required(ErrorMessage = "The OrderId field is required.")]
        public Guid OrderId { get; set; }


        [Required(ErrorMessage = "The ProductName field is required.")]
        [StringLength(50, ErrorMessage = "The ProductName field must not exceed 50 characters.")]
        public string? ProductName { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "The Quantity field must be a positive number.")]
        public int Quantity { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "The UnitPrice field must be a positive number.")]
        [Column(TypeName = "decimal")]
        public decimal UnitPrice { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "The total price of the order item.")]
        [Column(TypeName = "decimal")]
        public decimal TotalPrice { get; set; }
    }
}
