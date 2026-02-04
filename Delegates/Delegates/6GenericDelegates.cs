namespace Delegates
{
    internal class GenericDelegates
    {
        // Делегати з узагальненнями (generics) дозволяють створювати делегати,
        // які можуть працювати з різними типами даних без необхідності оголошувати окремі типи делегатів для кожного типу.

        // Це робить код більш гнучким і повторно використовуваним.

        public delegate T GenericDelegate<T>(T input);

        public void Example()
        {
            // Приклад використання делегата з узагальненнями
            GenericDelegate<int> square = Square;
            int result = square(5); // result буде 25

            GenericDelegate<string> toUpper = ToUpperCase;
            string textResult = toUpper("hello"); // textResult буде "HELLO"
        }

        private int Square(int number)
        {
            return number * number;
        }
        private string ToUpperCase(string text)
        {
            return text.ToUpper();
        }
    }
}
