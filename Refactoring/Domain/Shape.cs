namespace Refactoring.Domain
{
    public interface IShape
    {
        string Name { get; set; }
        double Area { get; set; }
        double CalculateSurfaceArea();
    }

    public enum ShapeTypes
    {
        square,
        circle,
        triangle,
        rectangle,
        trapezoid
    }
}
