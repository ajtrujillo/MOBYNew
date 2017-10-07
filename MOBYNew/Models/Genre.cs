using System.ComponentModel.DataAnnotations;

namespace MOBYNew.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Genre")]
        public string genreName { get; set; }

        public string genreCode { get; set; }
    }
}