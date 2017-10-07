using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select A Contact")]
        public Contact TRNContact { get; set; }
        public List<Item> TRNItems { get; set; }
        public Item TRNItem { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ReceiptModel.EntryDate is required")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "Associate")]
        public Guid EntryOwner { get; set; }

        public double? InvoiceTotal()
        {
            return TRNItems.Sum(item => item.Price);
        }
        public Transaction()
        {
            TRNItems = new List<Item>();
            EntryOwner = Guid.Empty;
            EntryDate = DateTime.Now;
            TRNContact = new Contact();
            TRNItem = new Item();
        }
    }
}