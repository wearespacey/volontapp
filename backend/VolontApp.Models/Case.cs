using System;
using System.Collections.Generic;

namespace VolontApp.Models
{
    public class Case
    {
        public string Id { get; set; }

        public string CoordinatorId { get; set; }
        public Coordinator Coordinator { get; set; } = null;

        public List<string> VolunteerIds { get; set; } = null;
        public List<Volunteer> Volunteers { get; set; } = null;

        public string ChildId { get; set; }
        public Child Child { get; set; } = null;

        public MissingStatus MissingStatus { get; set; } = MissingStatus.Missing;

        public MissingType MissingType { get; set; } = MissingType.Disappearence;

        public DateTime MissingDate { get; set; } = DateTime.UtcNow;

        public string MissingLocation { get; set; }

        public int MissingAge { get; set; }

        public int MissingHeight { get; set; }

        public string MissingDescription { get; set; }

        public string MissingPicture { get; set; }
    }
}
