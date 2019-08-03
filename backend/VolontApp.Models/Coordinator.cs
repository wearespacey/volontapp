using System.Collections.Generic;
using Newtonsoft.Json;

namespace VolontApp.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Coordinator : Worker
    {
        public List<string> VolunteerIds { get; set; } = null;

        public List<Volunteer> Volunteers { get; set; } = null;
    }
}
