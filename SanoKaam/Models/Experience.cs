
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanoKaam.Models
{
    public class Experience
    {
        [Key]
        public int? id { get; set; }

        public string Year { get; set; }

        public string? Level { get; set; }

        public string Position { get; set; }

        public string Organization { get; set; }

        
        public int ProfileId { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }

   

    }
}
