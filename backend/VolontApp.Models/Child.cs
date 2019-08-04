using System;

namespace VolontApp.Models
{
    public class Child
    {
        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; } = DateTime.UtcNow;
    }
}
