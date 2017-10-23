namespace Refactoring.Domain
{
    public class Square : Shape
    {
        private double Side { get; set; }

        public Square(double side)
        {
            Name = GetType().Name;
            Side = side;
        }

        public override double CalculateSurfaceArea()
        {
            Area = Side * Side;
            return Area;
        }
    }
}
