namespace Core.Models;

public class Performance
{
    public int PerformanceId { get; set; }
    public double Value { get; set; }

    public int SportsmanId { get; set; }
    public Sportsman Sportsman { get; set; }

    public int CompetitionId { get; set; }
    public Competition Competition { get; set; }

    public int SportTypeId { get; set; }
    public SportType SportType { get; set; }

    public override string ToString()
    {
        return $"{Competition}/n{Sportsman}/n{Value} {SportType}";
    }
}
