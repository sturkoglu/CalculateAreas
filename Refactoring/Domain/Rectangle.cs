namespace Refactoring.Domain
{
    public class Rectangle : Shape
    {
        private double Height { get; set; }
        private double Width { get; set; }

        public Rectangle(double height, double width)
        {
            Name = GetType().Name;
            Height = height;
            Width = width;
        }

        public override double CalculateSurfaceArea()
        {
            Area = Height * Width;
            return Area;
        }
    }
}
