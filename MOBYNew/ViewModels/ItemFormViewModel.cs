using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MOBYNew.Models;

namespace MOBYNew.ViewModels
{
    public class ItemFormViewModel
    {
        public IEnumerable<ItemGenre> Genres { get; set; }

        public IEnumerable<ItemCategory> Categories { get; set; }

        public int? Id { get; set; }

        [Display(Name = "Name")]
        [StringLength(255)]
        [Required]
        public string ItemName { get; set; }

        [Display(Name = "Genre")]
        public int? ItemGenreId { get; set; }

        [Display(Name = "Category")]
        public int? ItemCategoryId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "In Stock")]
        [Range(1, 20)]
        [Required]
        public int? QtyInStock { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Item" : "New Item";
            }
        }

        public ItemFormViewModel()
        {
            Id = 0;
        }

        public ItemFormViewModel(Item item)
        {
            Id = item.Id;
            ItemName = item.ItemName;
            ReleaseDate = item.ReleaseDate;
            QtyInStock = item.QtyInStock;
            ItemGenreId = item.ItemGenreId;
            ItemCategoryId = item.ItemCategoryId;
        }
    }
}