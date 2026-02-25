
namespace Delegates
{
    internal class Closure
    {
        public void Example()
        {
            // Замикання (closure) - це функція, яка має доступ до змінних з зовнішнього контексту, навіть після того, як цей контекст вийшов з області видимості.
            // Замикання дозволяють функціям "запам'ятовувати" стан, який був актуальним на момент їх створення.
            Func<int> counter = CreateCounter();
            Console.WriteLine(counter()); // Виведе: 1
            Console.WriteLine(counter()); // Виведе: 2
            Console.WriteLine(counter()); // Виведе: 3
        }
        private Func<int> CreateCounter()
        {
            int count = 0; // Змінна, яка буде захоплена замиканням
            return () =>
            {
                count++; // Збільшуємо значення count при кожному виклику
                return count; // Повертаємо поточне значення count
            };
        }

        public void Example2()
        {
            var actions = new List<Action>();

            
            for (int i = 0; i < 3; i++)
            {
                int r = i;
                actions.Add(() => Console.WriteLine(r));
            }

            
            foreach (var a in actions)
            {
                a();
            }
        }
    }
}
