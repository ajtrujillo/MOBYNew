using System.ComponentModel.DataAnnotations;

namespace MOBYNew.Models
{
    public class ItemGenre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Genre")]
        public string GenreName { get; set; }

        public string GenreCode { get; set; }
    }
}