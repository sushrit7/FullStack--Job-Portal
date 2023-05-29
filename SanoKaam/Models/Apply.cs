

using System.ComponentModel.DataAnnotations;

namespace SanoKaam.Models
{
    public class Apply
    {

        [Key]
        public int id { get; set; }

        public string JobId { get; set; }

        public string UserId { get; set; }

        public string Status { get; set; }
        public string JobTitle { get; set; }

        public string CompanyName { get; set; }

        public string EmployerId { get; set; }


        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PortfolioWebsite { get; set; }

        public string? Start { get; set; }

        public long PhoneNumber { get; set; }

        public string Relocate { get; set; }

        public string Reference { get; set; }

        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        public string Occupation { get; set; }

        public int ProfileId { get; set; }

        public  virtual Profile Profile { get; set; }

        public byte[] Photo { get; set; }


    }
}
