using System.ComponentModel.DataAnnotations;

namespace CA2MoviesAPI.Models
{
    public class Screening
    {
        [Required]
        public int ID { get; set; }    // not null
        [Required]
        // Cinema Name eg. Vue Cinema Dublin
        public string Name { get; set; }    // not null
        // foregin key property, null, follows convention for naming
        public int MovieID { get; set; }

        // navigation property to Movie for this screening
        public virtual Movie Movie { get; set; }
    }
}
