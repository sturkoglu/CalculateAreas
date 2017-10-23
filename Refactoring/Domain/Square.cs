namespace Refactoring.Domain
{
    public class Square : IShape
    {
        public string Name { get; set; }
        public double Area { get; set; }
        private double Side { get; set; }

        public Square(double side)
        {
            Name = GetType().Name;
            Side = side;
        }

        public double CalculateSurfaceArea()
        {
            Area = Side * Side;
            return Area;
        }
    }
}
