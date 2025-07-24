using System.Collections.Concurrent;
using EventEaseApp.Models;

namespace EventEaseApp.Services
{
    public class AttendanceService
    {
        private readonly List<AttendanceModel> _attendance = new();
        private readonly ConcurrentDictionary<Guid, IEnumerable<AttendanceModel>> _attendanceSummaryCache = new();

        public IEnumerable<AttendanceModel> GetAttendanceForEvent(Guid eventId)
        {
            // Try to get from cache
            if (_attendanceSummaryCache.TryGetValue(eventId, out var cached))
                return cached;

            // Compute and cache
            var summary = _attendance.Where(a => a.EventId == eventId).ToList();
            _attendanceSummaryCache[eventId] = summary;
            return summary;
        }

        public async Task<IEnumerable<AttendanceModel>> GetAttendanceForEventAsync(Guid eventId)
        {
            // Simulate async work
            await Task.Yield();
            return _attendance.Where(a => a.EventId == eventId).ToList();
        }

   /*      public void MarkAttendance(Guid eventId, string userEmail, bool isPresent)
        {
            var record = _attendance.FirstOrDefault(a => a.EventId == eventId && a.UserEmail == userEmail);
            if (record == null)
            {
                _attendance.Add(new AttendanceModel { EventId = eventId, UserEmail = userEmail, IsPresent = isPresent });
            }
            else
            {
                record.IsPresent = isPresent;
            }
            // Invalidate cache for this event
            _attendanceSummaryCache.TryRemove(eventId, out _);
        } */

        public async Task MarkAttendanceAsync(Guid eventId, string userEmail, bool isPresent)
        {
            await Task.Yield();
            var record = _attendance.FirstOrDefault(a => a.EventId == eventId && a.UserEmail == userEmail);
            if (record == null)
            {
                _attendance.Add(new AttendanceModel { EventId = eventId, UserEmail = userEmail, IsPresent = isPresent });
            }
            else
            {
                record.IsPresent = isPresent;
            }
            // Invalidate cache for this event
            _attendanceSummaryCache.TryRemove(eventId, out _);
        }

        public bool IsUserPresent(Guid eventId, string userEmail)
        {
            return _attendance.Any(a => a.EventId == eventId && a.UserEmail == userEmail && a.IsPresent);
        }
    }
}