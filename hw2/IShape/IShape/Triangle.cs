using Shape;

 class Triangle: IShape
{
    private double _side1;
    private double _side2;
    private double _side3;

    private double Side1
    {
        get => _side1;
        set
        {
            ValidateSide(value);
            _side1 = value;
        }
    }

    private double Side2
    {
        get => _side2;
        set
        {
            ValidateSide(value);
            _side2 = value;
        }
    }

    private double Side3
    {
        get => _side3;
        set
        {
            ValidateSide(value);
            _side3 = value;
        }
    }

    public Triangle(double a, double b, double c)
    {
        Side1 = a;
        Side2 = b;
        Side3 = c;

        bool isTriangleExists = ((Side1 < Side2 + Side3) || (Side2 < Side1 + Side3) || (Side3 < Side1 + Side2));

        if (!isTriangleExists)
        {
            throw new ArgumentException("Triangle with such sides does not exist");
        }
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

    private void ValidateSide(double side)
    {
        if (side < 0)
        {
            throw new ArgumentException("Side can't be a negative number");
        }
    }
}

