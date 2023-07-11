using Shapes;

namespace IShapeTests;

public class CircleTest
{
    [Test]
    public void Constructor_ValidArgument()
    {
        double radius = 10;

        Circle circle = new Circle(radius);

        Assert.That(circle.Radius, Is.EqualTo(radius));
    }

    [Test]
    public void Constructor_InvalidArgument()
    {
        double radius = 0;

        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    [Test]
    public void CalculatePerimeter_ValidArgument()
    {
        double radius = 10;
        double correctPerimeter = 2 * Math.PI * radius;

        Circle circle = new Circle(radius);
        double actualPerimeter = circle.CalculatePerimeter();

        Assert.That(actualPerimeter, Is.EqualTo(correctPerimeter));
    }

    [Test]
    public void CalculateArea_ValidArgument()
    {
        double radius = 10;
        double correctArea = Math.PI * radius * radius;

        Circle circle = new Circle(radius);
        double actualArea = circle.CalculateArea();

        Assert.That(actualArea, Is.EqualTo(correctArea));
    }
}