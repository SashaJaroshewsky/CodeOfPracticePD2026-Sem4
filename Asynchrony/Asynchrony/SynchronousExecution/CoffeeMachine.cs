namespace Asynchrony.SynchronousExecution
{
    internal class CoffeeMachine
    {
        public void MakeCoffee()
        {
            Console.WriteLine("Бариста починає готувати каву...");
            // Імітуємо час приготування кави
            Thread.Sleep(2000); // Затримка 2 секунди // Блокування потока на час приготування кави
            // Під час виконання Thread.Sleep потік, у якому виконується цей код, буде заблокований
            // і не зможе виконувати інші інструкції, доки не завершиться затримка. 
            Console.WriteLine("Бариста закінчив готувати каву!");
        }

    }
}
