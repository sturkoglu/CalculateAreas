using System;
using System.Collections.Generic;
using Refactoring.Domain;

namespace Refactoring.Services
{
    public interface ISelector
    {
        Shape Get(List<string> arrCommands);
    }

    public class ShapeSelector : ISelector
    {
        private readonly IDictionary<ShapeTypes, Func<List<string>, Shape>> commandShapeDict;

        public ShapeSelector()
        {
            commandShapeDict = new Dictionary<ShapeTypes, Func<List<string>, Shape>>
            {
                {ShapeTypes.square, GetSquare},
                {ShapeTypes.circle, GetCircle},
                {ShapeTypes.triangle, GetTriagle},
                {ShapeTypes.rectangle, GetRectangle},
                {ShapeTypes.trapezoid, GetTrapezoid}
            };
        }

        public Shape Get(List<string> arrCommands)
        {
            ShapeTypes shapeInput;

            if (!Enum.TryParse(arrCommands[1].ToLowerInvariant(), out shapeInput))
            {
                throw new Exception("Cannot create unknown shape!!!");
            }

            var shape = commandShapeDict[shapeInput];

            try
            {
                return shape.Invoke(arrCommands);
            }
            catch (Exception)
            {
                throw new Exception("Missing or invalid input for creating shape!!!");
            }
        }

        private static Trapezoid GetTrapezoid(List<string> arrCommands)
        {
            var height = double.Parse(arrCommands[2]);
            var upperWidth = double.Parse(arrCommands[3]);
            var lowerWidth = double.Parse(arrCommands[4]);
            return new Trapezoid(height, upperWidth, lowerWidth);
        }

        private static Rectangle GetRectangle(List<string> arrCommands)
        {
            var height = double.Parse(arrCommands[2]);
            var width = double.Parse(arrCommands[3]);
            return new Rectangle(height, width);
        }

        private static Triangle GetTriagle(List<string> arrCommands)
        {
            var height = double.Parse(arrCommands[2]);
            var width = double.Parse(arrCommands[3]);
            return new Triangle(height, width);
        }

        private static Circle GetCircle(List<string> arrCommands)
        {
            var radius = double.Parse(arrCommands[2]);
            return new Circle(radius);
        }

        private static Square GetSquare(List<string> arrCommands)
        {
            var side = double.Parse(arrCommands[2]);
            return new Square(side);
        }
    }
}
