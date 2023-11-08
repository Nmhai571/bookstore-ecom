using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("Pages")]
    public class PageModel
    {
        [Key]
        public Guid PageId { get; set; }
        public string PageName { get; set; }
        [MaxLength(255)]
        public string? Thumbnail { get; set; }
        public bool Pubished { get; set; }
        public string Contents { get; set; }
        public string? Title { get; set; }
        public string? MetaDesc { get; set; }
        public string? MetaKey { get; set; }
        public string? Alias { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Ordering { get; set; }
    }
}
