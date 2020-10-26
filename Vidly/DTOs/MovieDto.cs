using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int GenreId { get; set; }

        [Required(ErrorMessage = "The Release date field is required")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        //[MoviesStockValidations]
        [Range(1, 20)]
        //[Required(ErrorMessage = "The stock field is required")]
        public int Stock { get; set; }

        public GenreDTO Genre { get; set; }

    }
}