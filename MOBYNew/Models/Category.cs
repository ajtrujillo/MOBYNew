using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required, StringLength(255), Display(Name ="Category")]
		public string CategoryName { get; set; }

        [Display(Name ="Category Description")]
        public string CategoryDescription { get; set; }

		public int? CategoryCode { get; set; }

        public virtual ICollection<Item> Items { get; set; }
	}
}