namespace Shapes
{
    public class Circle : Shape
    {
        private double _radius;

        public override string ShapeName => nameof(Circle);

        public override void RequestDimensions()
        {
            RequestDimensionValue("radius", out _radius);
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }
}
