using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Vidly.Models
{
    public class Movie
    
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genres Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }  // foreign key

        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

    }


}