using System.ComponentModel.DataAnnotations;

namespace MOBYNew.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public double Price { get; set; }

        public double QtyInStock { get; set; }

        public ItemCategoryDto ItemCategoryDto { get; set; }

        public ItemGenreDto ItemGenreDto { get; set; }
    }
}