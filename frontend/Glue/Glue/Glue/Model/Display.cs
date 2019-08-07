using System;

namespace Glue.Model
{
    public class Display
    {
        public string Id { get; set; }

        public Coordinates Location { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateRemoved { get; set; }

        public string PhoneNumber { get; set; }
    }
}
