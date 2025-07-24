namespace EventEaseApp.Models
{
    public class AttendanceModel
    {
        public Guid EventId { get; set; }
        public string? UserEmail { get; set; }
        public bool IsPresent { get; set; }
    }
}