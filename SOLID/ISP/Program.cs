namespace ISP
{
    // ISP - Interface Segregation Principle (Принцип розділення інтерфейсів)
    // Клієнти не повинні залежати від інтерфейсів, які вони не використовують.

    // Простіше кажучи
    // Не змушуй клас реалізовувати те, що йому не потрібно.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    // ISP — це не:
    //“робіть 100 маленьких інтерфейсів”

    //ISP — це:
    //“інтерфейс має відображати реальну роль”
}
