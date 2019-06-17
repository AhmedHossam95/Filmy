using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Filmy.Models
{
    public class MemberMinAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.UnSpecified||customer.MembershipTypeId==MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate==null)
            {
                return new ValidationResult("Birth Date is required");
            }
            var customerAge = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (customerAge >= 18) ?
                ValidationResult.Success:
                new ValidationResult("your age must be at least 18 to sign up as a member");
        }


    }
}