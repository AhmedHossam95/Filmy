using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Filmy.Models;

namespace Filmy.DTOs
{
    public class CustomerDTO
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }

        
        public DateTime? BirthDate { get; set; }


        

        [Required]

        public int MembershipTypeId { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }

    }
}