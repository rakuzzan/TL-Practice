using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes;

internal class Circle
{
    private double _radius;
    
    public double Radius
    {
        get => _radius;
        set 
        { 
            if (value < 0)
            {
                throw new ArgumentException("Radius can't be a negative number");
            }

            _radius = value;
        }
    }

    public Circle (double radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI* Math.Pow(Radius, 2);
    }

    public double CalculatePerimetr()
    {
        return 2 + Math.PI * Radius;
    }
}
