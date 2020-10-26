using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MembershipTypesViewModel
    {
        public MembershipType MembershipType { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }

        


    }
}