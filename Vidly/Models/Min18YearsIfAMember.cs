using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cust = (Customer)validationContext.ObjectInstance;

            if (cust.MembershipTypeId == MembershipType.Unknown || 
                cust.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (cust.BirthDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - cust.BirthDate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Must be at least 18 years old for chosen Membership type.");
        }
    }
}