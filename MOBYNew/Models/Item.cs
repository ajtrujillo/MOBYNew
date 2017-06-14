using System;
using System.ComponentModel.DataAnnotations;

namespace MOBYNew.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name  { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}