using System.ComponentModel.DataAnnotations;

namespace MOBYNew.Models
{
    public class CartItem
    {
        [Key]
        public string CartItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

    }
}