namespace Core.Models;

public class SportType
{
    public int SportTypeId { get; set; }
    public string Title { get; set; }
    public string UnitOfMeasurment { get; set; }

    public override string ToString()
    {
        return $"{UnitOfMeasurment}, {Title}";
    }
}
