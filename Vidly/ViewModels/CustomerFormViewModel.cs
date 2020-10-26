using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public List<MembershipType> MembershipTypes{ get; set; }
        public string Title
        {
            get
            {
                if(Customer!=null && Customer.Id != 0)
                {
                    return "Edit User";
                }
                return "New User";
            }
        }
    }
}