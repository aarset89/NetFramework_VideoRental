using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.ViewModels;

namespace Vidly.Models.CustomValidations
{
    public class MoviesStockValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.Stock.ToString() == "")
                return new ValidationResult("You must filled this field");
            else
            if (movie.Stock > 20 || movie.Stock < 1)
                return new ValidationResult("Stock number must be between 1 and 20");
            else
                return ValidationResult.Success;
            

            


        }
    }
}