using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        public string Title {get; set;} = string.Empty;
        public string Director {get; set;} = string.Empty;
        public int DurationMinutes {get; set;}
        [Range(1,10)]
        public int Rating {get; set;}
    }
}