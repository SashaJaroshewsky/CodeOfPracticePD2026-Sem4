namespace Delegates
{
    internal class CreatingDelegateInstances
    {
        // Існує кілька способів створення екземплярів делегатів в C#.
        // Через ключове слово new
        // Використання імені методу без new

        private delegate void MyDelegate(string message);
        private void MethodA(string msg)
        {
            Console.WriteLine($"MethodA says: {msg}");
        }
        public void Example()
        {
            // 1. new ключове слово
            MyDelegate del2 = new MyDelegate(MethodA);

            // 2. Використання імені методу
            MyDelegate del = MethodA;

            // Який спосіб кращий?
            // Використання імені методу без new є більш сучасним і зручним способом створення екземплярів делегатів.
            // Він робить код більш читабельним і стислим.
            
        }
    }
}
