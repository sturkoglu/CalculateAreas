using System;

namespace Refactoring.Domain
{
    public class Circle : IShape
    {
        public string Name { get; set; }
        public double Area { get; set; }
        private double Radius { get; set; }

        public Circle(double radius)
        {
            Name = GetType().Name;
            Radius = radius;
        }

        public double CalculateSurfaceArea()
        {
            Area = Math.Round(Math.PI * (Radius * Radius), 2);
            return Area;
        }
    }
}
