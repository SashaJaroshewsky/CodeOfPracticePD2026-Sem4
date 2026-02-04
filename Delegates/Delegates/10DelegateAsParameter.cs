namespace Delegates
{
    internal class DelegateAsParameter
    {
        // Делегати можуть бути використані як параметри методів, що дозволяє передавати функції як аргументи.
        // Це корисно для створення гнучких і повторно використовуваних методів.


        public delegate int MathOperation(int a, int b);
        public void Example()
        {
            // Використання делегата як параметра методу
            int sum = PerformOperation(10, 5, Add);
            int product = PerformOperation(10, 5, Multiply);
            Console.WriteLine($"Sum: {sum}");         // Виведе: Sum: 15
            Console.WriteLine($"Product: {product}"); // Виведе: Product: 50
        }

        // Метод, який приймає делегат як параметр. Цей параметр називається callback.
        // Виконує операцію, визначену делегатом
        // Простими словами callback - "Я тобі передаю, ЩО робити, а КОЛИ робити — вирішуєш ти"
        private int PerformOperation(int a, int b, MathOperation operation)
        {
            return operation(a, b);
        }
        private int Add(int x, int y)
        {
            return x + y;
        }
        private int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
