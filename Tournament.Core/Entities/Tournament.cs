namespace Tournament.Core.Entities;

public class Tournament
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public ICollection<Game> Games { get; set; } = [];
}
