namespace Core.Models;

public class Sportsman
{
    public int SportsmanId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int CoachId { get; set; }
    public Coach Coach { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, {Coach}";
    }
}
