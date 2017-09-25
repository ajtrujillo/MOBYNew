using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class Invoice
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select A Contact")]
        public Contact Contact { get; set; }
        public List<Item> Items { get; set; }
        public Item NewItem { get; private set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ReceiptModel.EntryDate is required")]
        public DateTime EntryDate { get; set; }
        public Guid EntryOwner { get; set; }
        public string Name { get; set; }

        public double? InvoiceTotal()
        {
            return Items.Sum(item => item.Price);
        }
        public Invoice()
        {
            Items = new List<Item>();
            EntryOwner = Guid.Empty;
            EntryDate = DateTime.Now;
            Contact = new Contact();
            NewItem = new Item();
        }
    }
}