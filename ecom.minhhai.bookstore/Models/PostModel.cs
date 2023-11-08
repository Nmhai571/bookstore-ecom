
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("Posts")]
    public class PostModel
    {
        [Key]
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public string? Thumbnail { get; set; }
        public bool Published { get; set; }
        public string? Alias { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Author { get; set; }
        public string? Tags { get; set; }
        public bool IsHot { get; set; }
        public bool IsNewFeed { get; set; }
        public string? MetaDesc { get; set; }
        public string? MetaKey { get; set; }
        public int? View { get; set; }
        public virtual AccountModel? AccountModel { get; set; }
    }
}
