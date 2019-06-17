using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Filmy.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name="Date Of Birth")]
        [MemberMinAge]
        public  DateTime? BirthDate { get; set; }

        public virtual MembershipType MembershipType { get; set; }
        
        [Display(Name="Membership Type")]
        [Required]
        
        public int MembershipTypeId { get; set; }


        


    }
}