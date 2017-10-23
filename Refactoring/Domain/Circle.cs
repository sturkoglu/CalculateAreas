using System;

namespace Refactoring.Domain
{
    public class Circle : Shape
    {
        private double Radius { get; set; }

        public Circle(double radius)
        {
            Name = GetType().Name;
            Radius = radius;
        }

        public override double CalculateSurfaceArea()
        {
            Area = Math.Round(Math.PI * (Radius * Radius), 2);
            return Area;
        }
    }
}
