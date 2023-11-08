using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("Payments")]
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public IEnumerable<OrderModel>? OrderModels { get; set; }
        
    }
}
