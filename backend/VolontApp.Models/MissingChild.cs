using System;

namespace VolontApp.Models
{
    public class MissingChild
    {
        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime MissingDate { get; set; } = DateTime.UtcNow;

        public string MissingLocations { get; set; }

        public int MissingAge { get; set; }

        public MissingType MissingType { get; set; } = MissingType.Disappearence;

        public DateTime Birthday { get; set; } = DateTime.UtcNow;

        public int Height { get; set; }

        public string Description { get; set; }

        public string Attachment { get; set; }

        public MissingStatus Status { get; set; } = MissingStatus.Missing;
    }
}
