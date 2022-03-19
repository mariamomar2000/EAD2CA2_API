using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CA2MoviesAPI.Models
{
    public class MovieComment
    {
        [Required]
        public int ID { get; set; }     // PK
        [Required]
        public string Comment { get; set; } // not null
        [Required]
        public DateTime Created { get; set; }

        // foregin key property, null, follows convention for naming
        // update relationship through this property, not through navigation property
        public int MovieID { get; set; }

        // navigation property to Movie for this Comment
        public virtual Movie Movie { get; set; }
    }
}
