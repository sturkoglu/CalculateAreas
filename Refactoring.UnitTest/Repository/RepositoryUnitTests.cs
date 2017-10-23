using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.Domain;
using Refactoring.Repository;

namespace Refactoring.UnitTest.Repository
{
    [TestClass]
    public class RepositoryUnitTests
    {
        private readonly Mock<ILogger> mockLogger = new Mock<ILogger>();

        private Triangle triangle;
        private Circle circle;
        private ShapeRepository shapeRepository;

        private const double TriangleHeight = 13d;
        private const double TriangleWidth = 34d;
        private const double CircleRadius = 23d;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            triangle = new Triangle(TriangleHeight, TriangleWidth);
            circle = new Circle(CircleRadius);

            shapeRepository = new ShapeRepository(mockLogger.Object);
        }

        [TestMethod]
        public void ShapeRepositoryShouldHaveTwoShapes()
        {
            // Act
            shapeRepository.Add(triangle);
            shapeRepository.Add(circle);

            // Assert
            Assert.AreEqual(shapeRepository.shapeList.Count, 2);
        }

        [TestMethod]
        public void ShapeRepositoryShouldHaveTwoCalculatedAreas()
        {
            // Act
            shapeRepository.Add(triangle);
            shapeRepository.Add(circle);
            shapeRepository.CalculateSurfaceAreas();

            // Assert
            Assert.AreEqual(shapeRepository.shapeList.Count, 2);
        }

        [TestMethod]
        public void ShapeRepositoryShouldNotHaveAnyShapeAfterReset()
        {
            // Act
            shapeRepository.Add(triangle);
            shapeRepository.Add(circle);
            shapeRepository.Clear();

            // Assert
            Assert.AreEqual(shapeRepository.shapeList.Count, 0);
        }

        [TestMethod]
        public void ShapeRepositoryShouldNotHaveAnyCalculatedAreaAfterReset()
        {
            // Act
            shapeRepository.Add(triangle);
            shapeRepository.Add(circle);
            shapeRepository.CalculateSurfaceAreas();
            shapeRepository.Clear();

            // Assert
            Assert.AreEqual(shapeRepository.shapeList.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "There are no surface areas to print")]
        public void ShapeRepositoryShouldThrowExceptionPrint()
        {
            // Act
            shapeRepository.Print();

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "There are no surface areas to calculate")]
        public void ShapeRepositoryShouldThrowExceptionForCalculate()
        {
            // Act
            shapeRepository.CalculateSurfaceAreas();

            // Assert
        }
    }
}
