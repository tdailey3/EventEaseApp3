using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models
{
    public class EventCardModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int EventIntId { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        public string? EventName { get; set; }

        [Required(ErrorMessage = "Event date is required")]
        public DateTime? EventDate { get; set; }

        public string? Location { get; set; }
        public bool IsCompleted { get; set; }
        public string? Action { get; set; }

        public EventCardModel() { }

        public EventCardModel(string? eventName, DateTime? eventDate, string? location, bool isCompleted = false, string? action = null)
        {
            Id = Guid.NewGuid();
            EventName = eventName;
            EventDate = eventDate;
            Location = location;
            IsCompleted = isCompleted;
            Action = action;
        }
    }
}