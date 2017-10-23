namespace Refactoring.Domain
{
    public class Triangle : Shape
    {
        private double Height { get; set; }
        private double Width { get; set; }

        public Triangle(double height, double width)
        {
            Name = GetType().Name;
            Height = height;
            Width = width;
        }

        public override double CalculateSurfaceArea()
        {
            Area = 0.5 * (Height * Width);
            return Area;
        }
    }
}
