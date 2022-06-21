namespace Shapes
{
    public class Program
    {
        private static readonly List<string> Shapes = new List<string>
        {
            nameof(Circle),
            nameof(Rectangle),
            nameof(Triangle),
        };

        private static readonly Dictionary<string, Type> ShapeDictionary = Shapes
            .ToDictionary(shape => shape, GetShapeType);

        private static readonly string AvailableShapes = string.Join(", ", Shapes);

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("This program allows you to perform calculations on 2D shapes.");
                Console.WriteLine("Please make sure to use the same units for all dimensions entered.");
                Console.WriteLine();
                Console.WriteLine($"Available shapes: {AvailableShapes}");

                var userInput = RequestShapeName();
                var requestedShape = ParseShapeName(userInput);

                while (string.IsNullOrWhiteSpace(requestedShape))
                {
                    userInput = RequestValidShapeName();
                    requestedShape = ParseShapeName(userInput);
                }

                var shape = (Shape)Activator.CreateInstance(ShapeDictionary[requestedShape])!;
                ProcessShape(shape);

                if (!CalculateAnother())
                {
                    break;
                }
            }
        }

        private static bool CalculateAnother()
        {
            Console.Write("Calculate for another shape? (y/n)");
            var userInput = Console.ReadLine()!;

            return userInput.ToLower().StartsWith("y");
        }

        private static Type GetShapeType(string shapeName)
        {
            var typeName = $"{typeof(Program).Namespace}.{shapeName}, {typeof(Program).Namespace}";
            return Type.GetType(typeName)!;
        }

        private static string ParseShapeName(string userInput)
        {
            userInput = userInput.ToLower();

            try
            {
                var requestedShape = Shapes
                    .SingleOrDefault(shape => shape.ToLower().StartsWith(userInput));
                
                return requestedShape ?? string.Empty;
            }
            catch (InvalidOperationException)
            {
                // One or more shapes match
                return string.Empty;
            }
        }

        private static void ProcessShape(Shape shape)
        {
            shape.RequestDimensions();

            Console.WriteLine();
            Console.WriteLine($"Shape perimeter: {shape.CalculatePerimeter()}");
            Console.WriteLine($"Shape area: {shape.CalculateArea()}");
            Console.WriteLine();
        }

        private static string RequestShapeName()
        {
            Console.WriteLine();
            Console.Write("Please enter the shape you would like to use: ");
            return Console.ReadLine()!;
        }

        private static string RequestValidShapeName()
        {
            Console.WriteLine();
            Console.WriteLine($"Please enter a valid shape. Available shapes: {AvailableShapes}");
            return RequestShapeName();
        }
    }
}
