using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanoKaam.Models
{
    public class Education
    {
        [Key]
        public int id { get; set; }

        public string YearOfGraduation { get; set; }

        public string Level { get; set; }

        public string Degree { get; set; }

        public string Institution { get; set; }

        public string Grade { get; set; }


        public int ProfileId { get; set; }


        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }
    }
}
