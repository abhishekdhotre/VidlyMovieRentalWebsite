﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int Stock { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }

    //
}