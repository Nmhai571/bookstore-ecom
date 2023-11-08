using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("Books")]
    public class BookModel
    {
        [Key]
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string Author { get; set; }
        public Guid CategoryId { get; set; }
        public float Price { get; set; }
        public int? Discount { get; set; }
        [MaxLength(255)]
        public string? Thumbnail { get; set; }
        public DateTime CreateDate { get; set; }
        public bool BestSellers { get; set; }
        public bool HomeFlag { get; set; }
        public bool Active { get; set; }
        public string? Tags { get; set; }
        public string? Title { get; set; }
        public string? Alias { get; set; }
        public string? MetaDesc { get; set; }
        public string? MetaKey { get; set; }
        public int UnitsInStock { get; set; }
        public float OriginalPrice { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryModel? CategoryModel { get; set; }
        public IEnumerable<OrderDetailModel>? OrderDetailModels { get; set; }


    }
}
