using EventViewProvider.Service;
using Microsoft.AspNetCore.Mvc;

namespace EventViewProvider.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly EventFetchService _fetchService;

    public EventsController(EventFetchService fetchService)
    {
        _fetchService = fetchService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] bool sort = false,
        [FromQuery] string order = "asc",
        [FromQuery] string? location = null,
        [FromQuery (Name = "title")] string? titleSearch = null,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null)
        
    {
        var events = await _fetchService.GetEventsAsync();
        
        // Sortera (A-Ö eller Ö-A)
        if (sort)
        {
            events = order.ToLower() == "desc"
                ? events.OrderByDescending(e => e.Title).ToList()
                : events.OrderBy(e => e.Title).ToList();
            
        }

        // Filtrera via location (förlåtande, ej känslig)
        if (!string.IsNullOrWhiteSpace(location))
        {
            events = events
                .Where(e => e.Location.Contains(location, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        
        // Filtrera via titel (förlåtande, ej känslig)
        if (!string.IsNullOrWhiteSpace(titleSearch))
        {
            events = events
                .Where(e => e.Title.Contains(titleSearch, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Filtrera via datumintervall
        if (startDate.HasValue)
        {
            events = events
                .Where(e => e.Date >= startDate.Value)
                .ToList();
        }

        if (endDate.HasValue)
        {
            events = events
                .Where(e => e.Date <= endDate.Value)
                .ToList();
        }

        return Ok(events);
    }
}
