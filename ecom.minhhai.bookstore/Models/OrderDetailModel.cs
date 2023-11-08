using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("OrderDetails")]
    public class OrderDetailModel
    {
        [Key]
        public Guid OrderDetailModelId { get; set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
        public int OrderNumber { get; set; }
        public int Quanlity { get; set; }
        public int? Discount { get; set; }
        public float? Total { get; set; }
        public DateTime ShipDate { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderModel OrderModel { get; set; }
        [ForeignKey("BookId")]
        public virtual BookModel BookModel { get; set; }

    }
}
