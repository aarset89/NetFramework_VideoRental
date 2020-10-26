using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class NewRentalDTO
    {
        public int CustomerId { get; set; }
        public List<int> MoviesIds { get; set; }

    }
}