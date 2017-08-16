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

		[Required]
		[StringLength(255)]
		public string categoryName { get; set; }

		public int categoryCode { get; set; }
	}
}