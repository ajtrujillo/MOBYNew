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
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Genre")]
        [ForeignKey("ItemGenreId")]
        public ItemGenre ItemGenre { get; set; }
        public int ItemGenreId { get; set; }

        [Display(Name = "Category")]
        [ForeignKey("ItemCategoryId")]
        public virtual ItemCategory ItemCategory { get; set; }
        public int? ItemCategoryId { get; set; }

        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        public double? Price { get; set; }

        [Display(Name = "Barcode")]
        public double? ISBN13EAN { get; set; }

        [Display(Name = "In Stock")]
        public int? QtyInStock { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
    }
}