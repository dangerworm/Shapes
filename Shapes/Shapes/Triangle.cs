namespace Shapes
{
    public  class Triangle : Shape
    {
        private double _base;

        private double _height;

        public override string ShapeName => nameof(Triangle);

        public override void RequestDimensions()
        {
            RequestDimensionValue("base", out _base);
            RequestDimensionValue("height", out _height);
        }

        public override double CalculateArea()
        {
            return _base * _height / 2;
        }

        public override double CalculatePerimeter()
        {
            var hypotenuse = Math.Sqrt(Math.Pow(_base, 2) + Math.Pow(_height, 2));
            return _base + _height + hypotenuse;
        }
    }
}
