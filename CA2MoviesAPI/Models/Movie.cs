using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CA2MoviesAPI.Models
{
    public class Movie
    {
        [Required]
        public int ID { get; set; }             // PK 
        [Required]
        public string Name { get; set; }        // Not null
        [Required]
        public string Description { get; set; } // Not null
        [Required]
        public string Genre { get; set; }       // Not null
        [Range(0,5)]
        public int Rating { get; set; }         // null
        public int Count { get; set; }
        public double AvgRating
        {
            get
            {
                try
                {
                    return Rating / Count;
                } catch (DivideByZeroException)
                {
                    return 0.0;
                }
            }
        }
        public string Thumbnail { get; set; }   // null

        // navigation property to comments that movie contains, virtual => lazy loading
        public virtual ICollection<MovieComment> MovieComments { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
