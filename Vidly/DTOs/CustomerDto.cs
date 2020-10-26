using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[Is18YearsOldToBeAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribeToNewsletter { get; set; }

        public int MembershipTypeId { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }
    }
}