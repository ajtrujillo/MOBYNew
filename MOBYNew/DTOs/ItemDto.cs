using System.ComponentModel.DataAnnotations;

namespace MOBYNew.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public double Price { get; set; }

        public CategoryDto CategoryDto { get; set; }

        public GenreDto GenreDto { get; set; }
    }
}