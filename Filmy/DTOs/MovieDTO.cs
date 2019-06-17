using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmy.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        

        [Required]
        public int GenreId { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }


    }
}