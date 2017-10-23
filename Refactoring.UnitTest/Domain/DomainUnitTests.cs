using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.Domain;
using Refactoring.Repository;

namespace Refactoring.UnitTest.Domain
{
    [TestClass]
    public class UnitTest
    {
        private readonly Mock<ILogger> mockLogger = new Mock<ILogger>();

        private const double TriangleHeight = 13d;
        private const double TriangleWidth = 34d;
        private const double TriangleSurfaceArea = 221d;
        private const double CircleRadius = 23d;
        private const double CircleSurfaceArea = 1661.9d;
        private const double SquareSide = 17d;
        private const double SquareSurfaceArea = 289d;
        private const double RectangleHeight = 23d;
        private const double RectangleWidth = 67d;
        private const double RectangleSurfaceArea = 1541d;
        private const double TrapezoidHeight = 20d;
        private const double TrapezoidUpperWidth = 12d;
        private const double TrapezoidLowerWidth = 18d;
        private const double TrapezoidSurfaceArea = 300d;

        [TestMethod]
        public void TriangleCalculateSurfaceArea()
        {
            // Arrange
            var triangle = new Triangle(TriangleHeight, TriangleWidth);

            // Act
            var surfaceArea = triangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(TriangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CircleCalculateSurfaceArea()
        {
            // Arrange
            var circle = new Circle(CircleRadius);

            // Act
            var surfaceArea = circle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(CircleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void SquareCalculateSurfaceArea()
        {
            // Arrange
            var square = new Square(SquareSide);

            // Act
            var surfaceArea = square.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(SquareSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void RectangleCalculateSurfaceArea()
        {
            // Arrange
            var rectangle = new Rectangle(RectangleHeight, RectangleWidth);

            // Act
            var surfaceArea = rectangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(RectangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void TrapezoidCalculateSurfaceArea()
        {
            // Arrange
            var trapezoid = new Trapezoid(TrapezoidHeight, TrapezoidUpperWidth, TrapezoidLowerWidth);

            // Act
            var surfaceArea = trapezoid.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(TrapezoidSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CalculateSurfaceAreas()
        {
            // Arrange
            var triangle = new Triangle(TriangleHeight, TriangleWidth);

            var circle = new Circle(CircleRadius);

            var square = new Square(SquareSide);

            var rectangle = new Rectangle(RectangleHeight, RectangleWidth);

            var trapezoid = new Trapezoid(TrapezoidHeight, TrapezoidUpperWidth, TrapezoidLowerWidth);

            var expectedSurfaceAreas = new List<double>() { TriangleSurfaceArea, CircleSurfaceArea, SquareSurfaceArea, RectangleSurfaceArea, TrapezoidSurfaceArea };

            // Act
            var surfaceAreaCalculator = new ShapeRepository(mockLogger.Object);
            surfaceAreaCalculator.Add(triangle);
            surfaceAreaCalculator.Add(circle);
            surfaceAreaCalculator.Add(square);
            surfaceAreaCalculator.Add(rectangle);
            surfaceAreaCalculator.Add(trapezoid);
            surfaceAreaCalculator.CalculateSurfaceAreas();
            var surfaceAreas = surfaceAreaCalculator.surfaceAreaList;

            // Assert
            Assert.AreEqual(expectedSurfaceAreas[0], surfaceAreas[0]);
            Assert.AreEqual(expectedSurfaceAreas[1], surfaceAreas[1]);
            Assert.AreEqual(expectedSurfaceAreas[2], surfaceAreas[2]);
            Assert.AreEqual(expectedSurfaceAreas[3], surfaceAreas[3]);
        }



    }
}
