namespace Refactoring.Domain
{
    public abstract class Shape
    {
        public string Name;
        public double Area;
        public abstract double CalculateSurfaceArea();
    }

    enum ShapeTypes
    {
        square,
        circle,
        triangle,
        rectangle,
        trapezoid
    }
}
