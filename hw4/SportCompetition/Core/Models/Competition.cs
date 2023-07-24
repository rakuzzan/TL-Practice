namespace Core.Models;

public class Competition
{
    public int CompetitionId { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Venue { get; set; }

    public override string ToString()
    {
        return $"{Title}, {Date}, {Venue} ";
    }
}