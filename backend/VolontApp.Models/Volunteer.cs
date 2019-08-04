namespace VolontApp.Models
{
    public class Volunteer : Worker
    {
        public bool IsNotified { get; set; } = false;
        public Coordinator Coordinator { get; set; }
    }
}
