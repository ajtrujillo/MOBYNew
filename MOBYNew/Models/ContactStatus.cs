using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class ContactStatus
    {
        //public ContactStatus()
        //{ }

        public enum StatusType
        { Active, Inactive }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public string contactStatus { get; set; } = "Active";

        public StatusType? statusType { get; set; }

        public int? ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }

    }
}