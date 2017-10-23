namespace Refactoring.Domain
{
    public class Rectangle : IShape
    {
        public string Name { get; set; }
        public double Area { get; set; }
        private double Height { get; set; }
        private double Width { get; set; }

        public Rectangle(double height, double width)
        {
            Name = GetType().Name;
            Height = height;
            Width = width;
        }

        public double CalculateSurfaceArea()
        {
            Area = Height * Width;
            return Area;
        }
    }
}
