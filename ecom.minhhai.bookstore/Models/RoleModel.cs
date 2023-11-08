using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.minhhai.bookstore.Models
{
    [Table("Roles")]
    public class RoleModel
    {
        [Key]
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<AccountModel> AccountModels { get; set; }
    }
}
