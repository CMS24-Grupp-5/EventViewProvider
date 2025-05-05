using System.ComponentModel.DataAnnotations;

namespace EventViewProvider.Models;

public class Event
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }

    [Required]
    public string Location { get; set; } = string.Empty ;
    public string Description { get; set; } = string.Empty ;

}
