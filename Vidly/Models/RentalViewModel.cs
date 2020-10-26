using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class RentalViewModel
    {
        public Customer Customer { get; set; }
        public List<Movie> Movies { get; set; }
    }
}