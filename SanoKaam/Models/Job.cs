using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanoKaam.Models;

public class Job
{
    [Key]
    public int Id { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    public string JobTitle { get; set; }
    [System.ComponentModel.DataAnnotations.Required]
    public string JobType { get; set; }

    public string Location { get; set; }

    public int NumberOfPost { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    public string CompanyName { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    public string JobDescription { get; set; }

    public string Qualification { get; set; }

    public string Experience { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    public float Salary { get; set; }

    public string EmployerId { get; set; }

    public DateTime Deadline { get; set; }

    public byte[] CompanyLogo { get; set; }
}
    
