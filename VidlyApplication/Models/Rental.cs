using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyApplication.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer;

        public int CustomerId { get; set; }

        [Required]
        public Movie Movie;

        public int MovieId { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}