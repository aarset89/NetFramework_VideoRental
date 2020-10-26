using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vidly.Models.CustomValidations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name="Name of Movie")]
        public string Name { get; set; }

        [ForeignKey("Genre")]
        [Required(ErrorMessage = "The genre field is required")]
        public int GenreId { get; set; }
        
        public Genre Genre { get; set; }

        [Display(Name="Relese Date")]
        [Required(ErrorMessage = "The Release date field is required")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name="Number in Stock")]
        [MoviesStockValidations]
        [Range(1,20)]
        //[Required(ErrorMessage = "The stock field is required")]
        public int Stock { get; set; }

        public int AvailableMovies { get; set; }

    }
}