using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VolontApp.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Case
    {
        public string Id { get; set; }

        public string CoordinatorId { get; set; }
        public Coordinator Coordinator { get; set; }

        public List<string> VolunteerIds { get; set; }
        public List<Volunteer> Volunteers { get; set; }

        public string ChildId { get; set; }
        public Child Child { get; set; }

        public MissingStatus MissingStatus { get; set; } = MissingStatus.Missing;

        public MissingType MissingType { get; set; } = MissingType.Disappearence;

        public DateTime MissingDate { get; set; } = DateTime.UtcNow;

        public string MissingLocation { get; set; }

        public int MissingAge { get; set; }

        public int MissingHeight { get; set; }

        public string MissingDescription { get; set; }

        public string MissingPicture { get; set; }

        public IEnumerable<Display> Displays { get; set; }
        public IEnumerable<string> DisplayIds { get; set; }

    }
}
