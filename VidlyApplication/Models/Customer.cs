using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace VidlyApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer name.")] //will make the column not nullable
        [StringLength(255)] //will make the column of nvarchar(255)
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; } //? -> nullable column
        
        public bool isSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}