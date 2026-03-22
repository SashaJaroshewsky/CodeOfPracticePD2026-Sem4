namespace SerializationDeserialization
{
    internal class WhySerialization
    {
        // 1.
        List<string> players = new() { "Anna", "John", "Kate" };

        // Поки програма працює данні є
        // Але якщо ми закриємо програму, то данні будуть втрачені

        // Як зберегти данні, щоб вони були доступні після закриття програми?

        // 2.
        // Уявімо:

        // Frontend(JS)
        // Backend(C#)
        // Мобільний додаток
        // База даних
        // Інший сервер

        // Всі вони повинні "розуміти" одні й ті самі дані.
        public class Player
        {
            public string Name { get; set; }
            public int Level { get; set; }
        }
        // Цей клас існує лише в C#.

        // Тому потрібно перетворити об’єкт у текстовий універсальний формат.

        // Перший варіат — зберігати вручну як текст
        public void SavePlayer()
        {
            var player = new Player { Name = "Anna", Level = 5 };
            File.WriteAllText("player.txt", $"{player.Name};{player.Level}");
        }
        public Player LoadPlayer()
        {
            var data = File.ReadAllText("player.txt");
            var parts = data.Split(';');
            return new Player { Name = parts[0], Level = int.Parse(parts[1]) };
        }

        // Проблеми:
        // порядок має значення
        // додали нове поле → все ламається
        // складні об’єкти неможливо нормально зберігати
        // вкладені об’єкти — біль

        // Можна придумати різні способи, але це складно і неефективно.
        // І врешті решт ви прийдете до створення власного формату, який буде схожий на JSON або XML.
    }
}
