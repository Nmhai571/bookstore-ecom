using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("Orders")]
    public class OrderModel
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid AccountId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public string Address { get; set; }
        public Guid Province { get; set; }
        public Guid Ward { get; set; }
        public Guid District { get; set; }
        public float? TotalPrice { get; set; }
        public int? TransactStatusId { get; set; }
        public bool? Deleted { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentId { get; set; }
        public string? Note { get; set; }
        [ForeignKey("AccountId")]
        public virtual AccountModel AccountModel { get; set; }
        [ForeignKey("TransactStatusId")]
        public virtual TransactStatusModel TransactStatusModel { get; set; }
        [ForeignKey("PaymentId")]
        public virtual PaymentModel PaymentModel { get; set; }
        public IEnumerable<OrderDetailModel> OrderDetailModels { get; set; }
    }
}
