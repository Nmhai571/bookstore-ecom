
using System.ComponentModel.DataAnnotations;

namespace ecom.minhhai.bookstore.ViewModel
{
    public class OrderViewModel
    {
        public Guid CustomerId { get; set; }
        public Guid PaymentId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        public string Email  { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please select province ")]
        public Guid Province { get; set; }
        [Required(ErrorMessage = "Please select District ")]
        public Guid District { get; set; }
        [Required(ErrorMessage = "Please select Ward ")]
        public Guid Ward { get; set; }
        public string Note { get; set; }
    }
}
