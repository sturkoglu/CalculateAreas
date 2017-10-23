using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.Domain;
using Refactoring.Repository;
using Refactoring.Services;

namespace Refactoring.UnitTest.Services
{
    [TestClass]
    public class CommandOperationsUnitTests
    {
        private readonly Mock<IShapeRepository> mockShapeRepository = new Mock<IShapeRepository>();
        private readonly Mock<ISelector> mockShapeSelector = new Mock<ISelector>();
        private readonly Mock<ILogger> mockLogger = new Mock<ILogger>();

        private CommandOperations commandOperations;

        private readonly string validCommandLine = "Create Square 5,5";
        private readonly string invalidCommandLine = "sda Square 5,5";

        private readonly Square square = new Square(5.5d);
        private readonly List<string> validCreateCommandLine = new List<string>() { "Create", "Square", "5,5" };
        private readonly List<string> invalidCreateCommandLine = new List<string>() { "Create", "qweqweqwe", "5,5" };


        [TestInitialize]
        public void Setup()
        {
            // Arrange
            mockShapeSelector
                .Setup(x => x.Get(validCreateCommandLine))
                .Returns(square);
            mockShapeSelector
                .Setup(x => x.Get(invalidCreateCommandLine))
                .Throws(new Exception("Cannot create unknown shape!!!"));

            commandOperations = new CommandOperations(mockShapeRepository.Object, mockShapeSelector.Object, mockLogger.Object);
            
        }

        [TestMethod]
        public void ShapeSelectorGetShouldCallForValidCommandLine()
        {
            // Act
            commandOperations.ReadString(validCommandLine);

            // Assert
            mockShapeSelector.Verify(x => x.Get(It.IsAny<List<string>>()));
        }

        [TestMethod]
        public void ShapeSelectorGetShouldNotCallForInvalidCommandLine()
        {
            // Act
            commandOperations.ReadString(invalidCommandLine);

            // Assert
            mockShapeSelector.Verify(x => x.Get(It.IsAny<List<string>>()), Times.Never);
        }

        [TestMethod]
        public void ShapeSelectorCreateShouldCallForValidCreateCommandLine()
        {
            // Act
            commandOperations.Create(validCreateCommandLine);

            // Assert
            mockShapeRepository.Verify(x => x.Add(It.IsAny<IShape>()));
        }

        [TestMethod]
        public void ShapeSelectorCreateShouldNotCallForForInvalidCreateCommandLine()
        {
            // Act
            commandOperations.Create(invalidCreateCommandLine);

            // Assert
            mockShapeRepository.Verify(x => x.Add(It.IsAny<IShape>()), Times.Never());
        }
    }
}
