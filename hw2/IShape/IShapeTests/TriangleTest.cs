using Shapes;

namespace IShapeTests;

public class TriangleTest
{

        [Test]
        public void Constructor_ValidArgument()
        {
            double side1 = 10;
            double side2 = 12;
            double side3 = 12;

            Triangle triangle = new Triangle(side1, side2, side3);

            Assert.That(triangle.Side1, Is.EqualTo(side1));
            Assert.That(triangle.Side2, Is.EqualTo(side2));
            Assert.That(triangle.Side3, Is.EqualTo(side3));
        }

        [Test]
        public void Constructor_InvalidArgument()
        {
            double side1 = 1000;
            double side2 = 12;
            double side3 = 12;

            Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3));
        }

        [Test]
        public void CalculatePerimeter_ValidArgument()
        {
            double side1 = 10;
            double side2 = 12;
            double side3 = 12;

            Triangle triangle = new Triangle(side1, side2, side3);

            double correctPerimeter = triangle.Side1 + triangle.Side2 + triangle.Side3;

            double actualPerimeter = triangle.CalculatePerimeter();

            Assert.That(actualPerimeter, Is.EqualTo(correctPerimeter));
        }

        [Test]
        public void CalculateArea_ValidArgument()
        {
            double side1 = 10;
            double side2 = 12;
            double side3 = 12;

            Triangle triangle = new Triangle(side1, side2, side3);

            double halfPerimeter = triangle.CalculatePerimeter() / 2;
            double correctArea = Math.Sqrt(halfPerimeter * (halfPerimeter - triangle.Side1) *
                (halfPerimeter - triangle.Side2) * (halfPerimeter - triangle.Side3));

            double actualArea = triangle.CalculateArea();

            Assert.That(actualArea, Is.EqualTo(correctArea));
        }

        [Test]
        public void SetSide_InvalidArgument()
        {
            double side1 = 10;
            double side2 = 12;
            double side3 = 12;

            Triangle triangle = new Triangle(side1, side2, side3);


            Assert.Throws<ArgumentException>(() => triangle.Side1 = 10000000);
        }
}