using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.Domain;

namespace Refactoring.Repository
{
    public interface IShapeRepository
    {
        void CalculateSurfaceAreas();
        void Add(IShape shape);
        void Clear();
        void Print();

    }

    public class ShapeRepository : IShapeRepository
    {
        private readonly ILogger logger;
        public List<IShape> shapeList { get; set; }
        public List<double> surfaceAreaList { get; private set; }

        public ShapeRepository(ILogger logger)
        {
            this.logger = logger;
            shapeList = new List<IShape>();
            surfaceAreaList = new List<double>();
        }

        public void Add(IShape shape)
        {
            shapeList.Add(shape);
        }

        public void CalculateSurfaceAreas()
        {
            if (!shapeList.Any())
            {
                throw new Exception("There are no surface areas to calculate");
            }

            surfaceAreaList = shapeList.Select(x => x.CalculateSurfaceArea()).ToList();
        }

        public void Clear()
        {
            shapeList.Clear();
            surfaceAreaList.Clear();
        }

        public void Print()
        {
            if (!surfaceAreaList.Any())
            {
                throw new Exception("There are no surface areas to print");
            }

            var index = 0;
            foreach (var shape in shapeList)
            {
                logger.Log($"[{index++}] {shape.Name} surface area is {shape.Area}");
            }
        }
    }
}
