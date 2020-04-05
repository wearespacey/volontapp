namespace VolontApp.Models
{
    public class Volunteer : Worker
    {
        public bool IsNotified { get; set; } = false;
        public string CoordinatorId { get; set; }
    }
}
