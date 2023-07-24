namespace Core.Models;


public class Coach
{
    public int CoachId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, {BirthDate}";
    }
}
