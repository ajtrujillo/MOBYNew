using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOBYNew.Models;

namespace MOBYNew.ViewModels
{
    public class RandomItemViewModel
    {
        public Item Item { get; set; }
        public List<Contact> Contacts { get; set; }

    }
}