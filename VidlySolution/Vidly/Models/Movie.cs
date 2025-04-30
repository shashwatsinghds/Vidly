using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genres Genre { get; set; }
        public byte GenreId { get; set; }  // foreign key
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }

    }


}