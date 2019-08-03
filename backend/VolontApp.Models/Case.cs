using System;
using System.Collections.Generic;
using System.Text;

namespace VolontApp.Models
{
    public class Case
    {
        public string Id { get; set; }
        public Coordinator Coordinator { get; set; }
        public List<Volunteer> Volunteers { get; set; }
        public MissingChild MissingChild { get; set; }

        public MissingStatus MissingStatus { get; set; }
        public MissingType MissingType { get; set; }
    }
}
