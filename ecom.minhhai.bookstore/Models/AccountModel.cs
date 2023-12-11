using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("Accounts")]
    public class AccountModel : IdentityUser
    {
        public string? Password { get; set; }
        public bool? Active { get; set; }
        public Guid? District { get; set; }
        public Guid? Ward { get; set; }
        public string? FullName { get; set; }
        [MaxLength(255)]
        public string? Avarta { get; set; }
        public string? Address { get; set; }
        public Guid? LocationId { get; set; }
        public DateTime? Lastlogin { get; set; }
        public DateTime? CreateDate { get; set; }
        public IEnumerable<PostModel>? PostModels { get; set; }
        [ForeignKey("LocationId")]
        public virtual LocationModel? LocationModel { get; set; }
        public virtual IEnumerable<OrderModel>? OrderModels { get; set; }

    }
}
