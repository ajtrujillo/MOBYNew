using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOBYNew.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name  { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        public decimal Price { get; set; }
    }
}