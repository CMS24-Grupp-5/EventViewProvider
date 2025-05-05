using EventViewProvider.Models;
using System.Text.Json;

namespace EventViewProvider.Service;

public class EventFetchService
{
    private readonly HttpClient _httpClient;

    public EventFetchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Event>> GetEventsAsync()
    {
        var response = await _httpClient.GetAsync("https://localhost:7295/api/events");
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync();
        var events = await JsonSerializer.DeserializeAsync<List<Event>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

        return events ?? new List<Event>();
    }
}
