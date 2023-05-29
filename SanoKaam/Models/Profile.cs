using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanoKaam.Models
{
    public class Profile
    {
        [Key]
        public int? Id { get; set; }

        public string? UserId { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Email { get; set; }

        public string? PortfolioWebsite { get; set; }

     

        public long PhoneNumber { get; set; }

        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        public string Occupation { get; set; }

        public string Bio { get; set; }

        public bool DisplayCard { get; set; }

        public virtual List<Skill> Skill { get; set; }
        public virtual List<Experience> Experience { get; set; }

        public virtual List<Education> Education { get; set; }

        public byte[] Photo { get; set; }

        public virtual List<Apply> Apply { get; set; }
    }
}
