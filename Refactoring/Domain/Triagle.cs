namespace Refactoring.Domain
{
    public class Triangle : IShape
    {
        public string Name { get; set; }
        public double Area { get; set; }
        private double Height { get; set; }
        private double Width { get; set; }

        public Triangle(double height, double width)
        {
            Name = GetType().Name;
            Height = height;
            Width = width;
        }

        public double CalculateSurfaceArea()
        {
            Area = 0.5 * (Height * Width);
            return Area;
        }
    }
}
