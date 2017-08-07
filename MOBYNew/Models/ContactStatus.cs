using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class ContactStatus
    {
        [Key]
        public int Id { get; set; }
        public string contactStatus { get; set; }
    }
}