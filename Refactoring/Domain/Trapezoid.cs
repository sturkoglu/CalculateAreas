namespace Refactoring.Domain
{
    public class Trapezoid : IShape
    {
        public string Name { get; set; }
        public double Area { get; set; }
        private double Height { get; set; }
        private double UpperWidth { get; set; }
        private double LowerWidth { get; set; }

        public Trapezoid(double height, double upperWidth, double lowerWidth)
        {
            Name = GetType().Name;
            Height = height;
            UpperWidth = upperWidth;
            LowerWidth = lowerWidth;
        }

        public double CalculateSurfaceArea()
        {
            Area = ((UpperWidth + LowerWidth) / 2) * Height;
            return Area;
        }
    }
}
