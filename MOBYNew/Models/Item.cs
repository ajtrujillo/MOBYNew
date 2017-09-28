using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOBYNew.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name ="Name")]
        public string ItemName { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Genre")]
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        [Display(Name = "Category")]
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int? CategoryId { get; set; }

        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        public double? Price { get; set; }

        [Display(Name = "Barcode")]
        public double? ISBN13EAN { get; set; }

        public int? QtyInStock { get; set; }
    }
}