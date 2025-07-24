using EventEaseApp.Models;

namespace EventEaseApp.Services
{
    public class EventServices
    {
        public List<EventCardModel> Events { get; } = new();

        private readonly ILogger<EventServices> _logger;
        //private int lastIntId = 0; // Start at 0
        // Changed to start at 5 to match the initial events in the constructor
        private int lastIntId = 5; // Start at 5

        public EventServices(ILogger<EventServices> logger)
        {
            _logger = logger;
            // Initialize events
             _logger.LogInformation("EventServices initialized.");
             // Initialize with 5 events
            Events.Add(new EventCardModel { EventIntId = 1, EventName = "Conference", EventDate = DateTime.Today.AddDays(1), Location = "Hall A", IsCompleted = false });
            Events.Add(new EventCardModel { EventIntId = 2, EventName = "Workshop", EventDate = DateTime.Today.AddDays(2), Location = "Room 101", IsCompleted = false });
            Events.Add(new EventCardModel { EventIntId = 3, EventName = "Meetup", EventDate = DateTime.Today.AddDays(3), Location = "Cafe Central", IsCompleted = false });
            Events.Add(new EventCardModel { EventIntId = 4, EventName = "Webinar", EventDate = DateTime.Today.AddDays(4), Location = "Online", IsCompleted = false });
            Events.Add(new EventCardModel { EventIntId = 5, EventName = "Expo", EventDate = DateTime.Today.AddDays(5), Location = "Exhibition Center", IsCompleted = false });

            _logger.LogInformation("EventServices initialized with {Count} events.", Events.Count);

        }
        public async Task<IEnumerable<EventCardModel>> GetEventsAsync()
        {
            _logger.LogInformation("Retrieving all events.");
            return await Task.FromResult(Events);
        }



        public void AddEvent(EventCardModel eventCard)
        {
            _logger.LogInformation("Adding new event: {EventName}", eventCard.EventName);

            eventCard.Id = Guid.NewGuid();
            eventCard.EventIntId = ++lastIntId;
            Events.Add(new EventCardModel
            {
                Id = eventCard.Id,
                EventIntId = eventCard.EventIntId,
                EventName = eventCard.EventName,
                EventDate = eventCard.EventDate,
                Location = eventCard.Location,
                IsCompleted = false
            });           
            _logger.LogInformation($"Event added: {eventCard.EventName} with ID {eventCard.Id}, EventIntId {eventCard.EventIntId}, Date {eventCard.EventDate}, Location {eventCard.Location}");
        }

        public void EditEvent(Guid id, EventCardModel eventCard)
        {
          
                var evt = Events.FirstOrDefault(e => e.Id == id);
            if (evt != null)
            {
                evt.EventName = eventCard.EventName;
                evt.EventDate = eventCard.EventDate;
                evt.Location = eventCard.Location;
                _logger.LogInformation($"Event edited: {eventCard.EventName} with ID {id}, EventIntId {evt?.EventIntId}, EventName {evt?.EventName}, Date {evt?.EventDate}, Location {evt?.Location}");
                }
            else
            {
                _logger.LogWarning($"Event with ID {id} not found for editing.");
            }                
        }
           
        

        public async Task DeleteEventAsync(Guid id)
        {
            var evt = Events.FirstOrDefault(e => e.Id == id);
            if (evt != null)
            {
            Events.Remove(evt);
            }

            _logger.LogInformation($"Event deleted with ID {id}, EventIntId {evt?.EventIntId}, EventName {evt?.EventName}, Date {evt?.EventDate}, Location {evt?.Location}");
            await Task.CompletedTask;
        }

        public void CompleteEvent(Guid id)
        {
            var evt = Events.FirstOrDefault(e => e.Id == id);
            if (evt != null)
            {
                evt.IsCompleted = true;
            }

            _logger.LogInformation($"Event completed with ID {id}, EventIntId {evt?.EventIntId}, EventName {evt?.EventName}, Date {evt?.EventDate}, Location {evt?.Location}");
        }

        public void UndoCompleteEvent(Guid id)
        {
            var evt = Events.FirstOrDefault(e => e.Id == id);
            if (evt != null)
            {
                evt.IsCompleted = false;
            }

            _logger.LogInformation($"Event completion undone with ID {id}, EventIntId {evt?.EventIntId}, EventName {evt?.EventName}, Date {evt?.EventDate}, Location {evt?.Location}");
        }
    }
}