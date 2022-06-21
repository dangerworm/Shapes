namespace Shapes
{
    public abstract class Shape
    {
        public abstract string ShapeName { get; }

        public abstract void RequestDimensions();

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

        public double RequestDimensionValue(string dimensionName, out double dimensionValue)
        {
            var userInput = "init";

            while (!double.TryParse(userInput, out dimensionValue))
            {
                Console.WriteLine();

                if (userInput != "init")
                {
                    Console.WriteLine("Please enter a number.");
                }

                Console.Write($"What is the shape's {dimensionName}? ");
                userInput = Console.ReadLine();
            }

            return dimensionValue;
        }
    }
}
