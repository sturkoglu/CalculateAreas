using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Domain;
using Refactoring.Repository;
using Refactoring.Services;

namespace Refactoring.UnitTest.Services
{
    [TestClass]
    public class ShapeSelectorUnitTests
    {
        private readonly List<string> CreateSquareCommandLine = new List<string>() { "Create", "Square", "5,5" };
        private readonly List<string> CreateInvalidShapeCommandLine = new List<string>() { "Create", "qweqweqwe", "5,5" };
        private readonly List<string> CreateWithMissingInputCommandLine = new List<string>() { "Create", "triangle", "5,5" };
        private readonly List<string> CreateWithInvalidInputCommandLine = new List<string>() { "Create", "triangle", "5,5", "q1" };

        private const double SquareSide = 5.5d;

        [TestMethod]
        public void ShapeSelectorShouldReturnCorrectShape()
        {
            // Arrange
            var shapeSelector = new ShapeSelector();
            var square = new Square(SquareSide);

            // Act
            var shape = shapeSelector.Get(CreateSquareCommandLine);

            // Assert
            Assert.AreEqual(shape.Name, square.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot create unknown shape!!!")]
        public void ShapeSelectorShouldThrowExceptionWhenWrongShapeType()
        {
            // Arrange
            var shapeSelector = new ShapeSelector();

            // Act
            var shape = shapeSelector.Get(CreateInvalidShapeCommandLine);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Missing or invalid input for creating shape!!!")]
        public void ShapeSelectorShouldThrowExceptionWhenMissingInput()
        {
            // Arrange
            var shapeSelector = new ShapeSelector();

            // Act
            var shape = shapeSelector.Get(CreateWithMissingInputCommandLine);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Missing or invalid input for creating shape!!!")]
        public void ShapeSelectorShouldThrowExceptionWhenInvalidInput()
        {
            // Arrange
            var shapeSelector = new ShapeSelector();

            // Act
            var shape = shapeSelector.Get(CreateWithInvalidInputCommandLine);

            // Assert
        }
    }
}
