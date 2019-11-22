using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Released Date")]
        public DateTime? RealeaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        public byte? Stock { get; set; }

        public string Title
        {
            get
            {
               
                return Id !=0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            RealeaseDate = movie.RealeaseDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }
    }
}