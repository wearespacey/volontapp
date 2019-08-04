using System.ComponentModel.DataAnnotations;

namespace VolontApp.Models
{
    public class Worker
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber{ get; set; }

        //[Required]
        public string InstallId { get; set; }

        public string Location { get; set; }
    }
}
