using ecom.minhhai.bookstore.Models;

namespace ecom.minhhai.bookstore.ViewModel
{
    public class CartViewModel
    {
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
        public float? TotalPrice => Book.Price * Quantity;
    }
}
