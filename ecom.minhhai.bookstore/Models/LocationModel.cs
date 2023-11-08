using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("Locations")]
    public class LocationModel
    {
        [Key]
        public Guid LocationId { get; set; }
        public string Name { get; set; }
        public string ?Type { get; set; }
        public string? Slug { get; set; }
        public string ?NameWithType { get; set; }
        public Guid? Parent { get; set; }
        public int? Levels { get; set; }
        public IEnumerable<AccountModel>? accountModels { get; set; }
    }
}
