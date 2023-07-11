using Shapes;

namespace IShapeTests;

public class SquareTest
{
    [Test]
    public void Constructor_ValidArgument()
    {
        double sideLength = 10;

        Square square = new Square(sideLength);

        Assert.That(square.Side, Is.EqualTo(sideLength));
    }

    [Test]
    public void Constructor_InvalidArgument()
    {
        double sideLength = 0;

        Assert.Throws<ArgumentException>(() => new Square(sideLength));
    }

    [Test]
    public void CalculatePerimeter_ValidArgument()
    {
        double sideLength = 10;
        double correctPerimeter = sideLength * sideLength;

        Square square = new Square(sideLength);
        double actualPerimeter = square.CalculateArea();

        Assert.That(actualPerimeter, Is.EqualTo(correctPerimeter));
    }

    [Test]
    public void CalculateArea_ValidArgument()
    {
        double sideLength = 10;
        double correctArea = sideLength * sideLength;

        Square square = new Square(sideLength);
        double actualArea = square.CalculateArea();

        Assert.That(actualArea, Is.EqualTo(correctArea));
    }
}