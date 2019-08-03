using System;

namespace VolontApp.Models
{
    public class Worker
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber{ get; set; }

        public string InstallId { get; set; }
    }
}
