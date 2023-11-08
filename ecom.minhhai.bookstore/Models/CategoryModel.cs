using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("Categories")]
    public class CategoryModel
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? Ordering { get; set; }
        public bool Published { get; set; }
        public string? Title { get; set; }
        public string? Alias { get; set; }
        public string? MetaDesc { get; set; }
        public string? MetaKey { get; set; }
        public string? Cover { get; set; }
        public string? SchemaMarkup { get; set; }
        public IEnumerable<BookModel>? BookModels { get; set; }

    }
}
