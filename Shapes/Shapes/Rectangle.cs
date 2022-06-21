namespace Shapes
{
    public class Rectangle : Shape
    {
        private double _width;

        private double _height;

        public override string ShapeName => nameof(Rectangle);

        public override void RequestDimensions()
        {
            RequestDimensionValue("width", out _width);
            RequestDimensionValue("height", out _height);
        }

        public override double CalculateArea()
        {
            return _width * _height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (_width + _height);
        }
    }
}
