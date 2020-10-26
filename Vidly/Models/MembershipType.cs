using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        [Range(0,12,ErrorMessage ="Duration must be between 0 and 12 months")]
        [RegularExpression("([0-9][0-9]*)")]
        public byte DurationInMonths { get; set; }

        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100 %")]
        [RegularExpression("([0-9][0-9]*)")]
        public byte DiscountRate { get; set; }

        public static readonly byte unknown = 0;
        public static readonly byte PayAsYouGo = 1;

        public enum Time
        {
            [Display(Name = "Pay As You Go")]
            PayAsYouGo = 0,
            [Display(Name = "Monthly")]
            Monthly = 1,
            [Display(Name = "Quaterly")]
            Quaterly = 3,
            [Display(Name = "Annually")]
            Annually = 12
        }
    }
}