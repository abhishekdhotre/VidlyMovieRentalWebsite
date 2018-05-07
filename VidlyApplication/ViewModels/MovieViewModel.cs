using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyApplication.Models;

namespace VidlyApplication.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}