using System;

namespace VolontApp.Models
{
    public class Display
    {
        public string Id { get; set; }

        public Coordinates Location { get; set; } = new Coordinates();

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime? DateRemoved { get; set; } = DateTime.UtcNow;

        public string PhoneNumber { get; set; }
    }
}
