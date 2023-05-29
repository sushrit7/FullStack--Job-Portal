namespace SanoKaam.Models
{
    public class Application
    {
        public virtual List<Job> Job { get; set; }

        public virtual List<Profile> Profile { get; set; }

        public string EmployerId { get; set; }

        public string Status { get; set; }
    }

}
