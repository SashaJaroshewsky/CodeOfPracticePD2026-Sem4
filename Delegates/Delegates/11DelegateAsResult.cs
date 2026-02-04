namespace Delegates
{
    internal class DelegateAsResult
    {
        // Делегати можуть бути використані як типи повернення методів.
        // Це дозволяє методам повертати функції, які можуть бути викликані пізніше.

        public delegate int MathOperation(int a, int b);
        public void Example()
        {
            // Отримання делегата як результату методу
            MathOperation operation = GetOperation("add");
            int result = operation(10, 5); // Виклик делегата
            Console.WriteLine($"Result: {result}"); // Виведе: Result: 15
        }

        // Метод, який повертає делегат на основі вхідного параметра
        private MathOperation GetOperation(string operationType)
        {
            if (operationType == "add")
            {
                return Add;
            }
            else if (operationType == "subtract")
            {
                return Subtract;
            }
            else
            {
                throw new ArgumentException("Invalid operation type");
            }
        }

        private int Add(int x, int y)
        {
            return x + y;
        }
        private int Subtract(int x, int y)
        {
            return x - y;
        }
    }
}
