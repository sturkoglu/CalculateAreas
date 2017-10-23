using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Domain;
using Refactoring.Repository;

namespace Refactoring.UnitTest.Repository
{
    [TestClass]
    public class RepositoryUnitTests
    {
        private const double TriangleHeight = 13d;
        private const double TriangleWidth = 34d;
        private const double CircleRadius = 23d;

        [TestMethod]
        public void ShapeRepositoryShouldHaveTwoShapes()
        {
            // Arrange
            var triangle = new Triangle(TriangleHeight, TriangleWidth);
            var circle = new Circle(CircleRadius);

            var shapeRepository = new ShapeRepository();

            // Act
            shapeRepository.Add(triangle);
            shapeRepository.Add(circle);

            // Assert
            Assert.AreEqual(shapeRepository.shapeList.Count, 2);
        }

        [TestMethod]
        public void ShapeRepositoryShouldHaveTwoCalculatedAreas()
        {
            // Arrange
            var triangle = new Triangle(TriangleHeight, TriangleWidth);
            var circle = new Circle(CircleRadius);

            var shapeRepository = new ShapeRepository();

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
            // Arrange
            var triangle = new Triangle(TriangleHeight, TriangleWidth);
            var circle = new Circle(CircleRadius);

            var shapeRepository = new ShapeRepository();

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
            // Arrange
            var triangle = new Triangle(TriangleHeight, TriangleWidth);
            var circle = new Circle(CircleRadius);

            var shapeRepository = new ShapeRepository();

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
            // Arrange
            var shapeRepository = new ShapeRepository();

            // Act
            shapeRepository.Print();

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "There are no surface areas to calculate")]
        public void ShapeRepositoryShouldThrowExceptionForCalculate()
        {
            // Arrange
            var shapeRepository = new ShapeRepository();

            // Act
            shapeRepository.CalculateSurfaceAreas();

            // Assert
        }
    }
}
