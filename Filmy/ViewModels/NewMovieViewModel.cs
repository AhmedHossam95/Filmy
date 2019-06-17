using System;
using System.Collections.Generic;
using System.Linq;
using Filmy.Models;
using System.Web;

namespace Filmy.ViewModels
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}