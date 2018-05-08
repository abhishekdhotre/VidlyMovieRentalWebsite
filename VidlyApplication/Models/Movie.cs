using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyApplication.Models
{
    public class Movie
    {
        //Int and byte are by default required 
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int Stock { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }

    //
}