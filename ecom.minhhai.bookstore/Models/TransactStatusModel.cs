using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("TransactStatus")]
    public class TransactStatusModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactStatusId { get; set; }
        public string Status { get; set; }
        public IEnumerable<OrderModel>? OrderModels { get; set; }


    }
}
