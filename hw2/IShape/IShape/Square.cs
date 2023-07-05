namespace Shapes;

internal class Square
{
    private double _side;

    public double Side
    {
        get => _side; 
        set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Side of Square can't be a negative number");
            }

            _side = value;
        }
    }
    public Square()
    {
        Side = _side;
    }

    public double CalculateArea()
    {
        return Math.Pow(Side, 2);
    }

    public double CalculatePerimetr()
    {
        return Side * 4;
    }
}
