using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanoKaam.Models
{
    public class Skill
    {
        [Key]
        public int id { get; set; }

        public string Skills { get; set; }

        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }

        public int ProfileId { get; set; }
    }
}
