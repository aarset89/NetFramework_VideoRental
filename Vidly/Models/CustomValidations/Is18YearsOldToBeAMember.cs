using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Is18YearsOldToBeAMember : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationcontext)
        {
            var customer = (Customer)validationcontext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Must be enter a birthdate");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age <= 18 )
                ? new ValidationResult("Must be older than 18") 
                :  ValidationResult.Success;

        }

    }
}