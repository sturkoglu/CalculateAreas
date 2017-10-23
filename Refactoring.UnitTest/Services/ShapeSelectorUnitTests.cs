using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Domain;
using Refactoring.Services;

namespace Refactoring.UnitTest.Services
{
    [TestClass]
    public class ShapeSelectorUnitTests
    {
        private readonly List<string> createSquareCommandLine = new List<string>() { "Create", "Square", "5,5" };
        private readonly List<string> createInvalidShapeCommandLine = new List<string>() { "Create", "qweqweqwe", "5,5" };
        private readonly List<string> createWithMissingInputCommandLine = new List<string>() { "Create", "triangle", "5,5" };
        private readonly List<string> createWithInvalidInputCommandLine = new List<string>() { "Create", "triangle", "5,5", "q1" };

        private Square square;
        private ShapeSelector shapeSelector;
        private const double SquareSide = 5.5d;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            shapeSelector = new ShapeSelector();
            square = new Square(SquareSide);
        }

        [TestMethod]
        public void ShapeSelectorShouldReturnCorrectShape()
        {
            // Act
            var shape = shapeSelector.Get(createSquareCommandLine);

            // Assert
            Assert.AreEqual(shape.Name, square.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot create unknown shape!!!")]
        public void ShapeSelectorShouldThrowExceptionWhenWrongShapeType()
        {
            // Act
            var shape = shapeSelector.Get(createInvalidShapeCommandLine);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Missing or invalid input for creating shape!!!")]
        public void ShapeSelectorShouldThrowExceptionWhenMissingInput()
        {
            // Act
            var shape = shapeSelector.Get(createWithMissingInputCommandLine);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Missing or invalid input for creating shape!!!")]
        public void ShapeSelectorShouldThrowExceptionWhenInvalidInput()
        {
            // Act
            var shape = shapeSelector.Get(createWithInvalidInputCommandLine);

            // Assert
        }
    }
}
