namespace Shapes;

 public class Triangle: IShape
{
    private double _side1;
    private double _side2;
    private double _side3;


    public double Side1
    {
        get => _side1;
        set
        {
            ValidateTriangleSide(value);
            _side1 = value;
            ValidateTriangle();
        }
    }

    public double Side2
    {
        get => _side2;
        set
        {
            ValidateTriangleSide(value);
            _side2 = value;
            ValidateTriangle();
        }
    }

    public double Side3
    {
        get => _side3;
        set
        {
            ValidateTriangleSide(value);
            _side3 = value;
            ValidateTriangle();
        }
    }

    public Triangle(double a, double b, double c)
    {
        _side1 = a;
        _side2 = b;
        _side3 = c;

        ValidateTriangle();
    }

    public double CalculateArea()
    {
        double halfPm = CalculatePerimeter() / 2;
        return Math.Sqrt(halfPm * (halfPm - Side1) * (halfPm - Side2) * (halfPm - Side3));
    }

    public double CalculatePerimeter()
    {
        return Side1 + Side2 + Side3;
    }

    private void ValidateTriangleSide(double side)
    { 
        if (side <= 0)
        {
            throw new ArgumentException("Side must be > 0");
        }
    }

    private void ValidateTriangle()
    {
        bool isTriangleExists = ((Side1 + Side2 > Side3) &&
                                 (Side1 + Side3 > Side2) &&
                                 (Side2 + Side3 > Side1));
        if (!isTriangleExists) 
        {
            throw new ArgumentException("This triangle can't exist");
        }
    }
}

