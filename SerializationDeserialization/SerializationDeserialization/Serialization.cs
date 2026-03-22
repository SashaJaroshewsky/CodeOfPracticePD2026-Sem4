using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationDeserialization
{
    // Серіалізація — це процес перетворення об’єкта в послідовність байтів або текстовий формат для зберігання або передачі даних.
    // Об’єкт → JSON → файл / мережа / база даних

    // У C# є вбудовані механізми для серіалізації, такі як System.Text.Json та Newtonsoft.Json, які дозволяють легко перетворювати об’єкти в JSON та навпаки.

    public class Player
    {
        // Серіалізувати можна будь-який клас, який має публічні властивості або поля. Властивості повинні мати геттери та сеттери, щоб вони могли бути серіалізовані та десеріалізовані.
        public string Name { get; set; }
        public int Level { get; set; }

        //[JsonInclude]
        private int health = 100; // Це поле не буде серіалізовано, оскільки воно не є публічним властивістю
        // Якщо потрібно серіалізувати приватне поле, можна використовувати атрибут [JsonInclude] або створити публічну властивість для нього.
        // Але зазвичай рекомендується серіалізувати лише публічні властивості, щоб зберегти інкапсуляцію та контроль над даними.

        public string[] Inventory { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} is at level {Level} with inventory: {string.Join(", ", Inventory)}, {health}");
        }
    }
    public class Serialization
    {
        public string SavePlayer(Player player)
        {
            string json = JsonSerializer.Serialize(player);
            File.WriteAllText("player.json", json);
            return json;
        }

        public void Example()
        {
            Player player = new Player
            {
                Name = "Hero",
                Level = 10,
                Inventory = ["Sword", "Shield", "Potion"]
            };

            var json = SavePlayer(player);
            Console.WriteLine(json);
        }

        // JsonSerializerOptions - це клас, який дозволяє налаштовувати поведінку серіалізації та десеріалізації JSON.
        // Він містить різні властивості, які можна використовувати для контролю формату JSON, обробки null-значень, іменування полів та інших аспектів серіалізації.

        public string CustomSerialization( Player player)
        {
            
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Форматування JSON з відступами для кращої читабельності
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Використання camelCase для імен полів
                // IgnoreNullValues = true, // Ігнорувати null-значення під час серіалізації
                // Converters = { new JsonStringEnumConverter() } // Додати конвертер для серіалізації enum як рядків
            };
            string json = JsonSerializer.Serialize(player, options);
            return json;
        }

        public void Example2()
        {
            Player player = new Player
            {
                Name = "Hero",
                Level = 10,
                Inventory = ["Sword", "Shield", "Potion"]
            };

            var json = CustomSerialization(player);
            Console.WriteLine(json);
            File.WriteAllText("player_custom.json", json);
        }

        // Метод серіалізації має багато перегрузок, які дозволяють серіалізувати об’єкти різних типів, з різними налаштуваннями та в різні формати (наприклад, потоки, текстові файли тощо).
        // Всі його перегрузки зводяться до трьох питань:
        // 1. Що серіалізувати? (який об’єкт або тип)
        // 2. Куди серіалізувати? (рядок, файл, потік тощо)
        // 3. Які налаштування використовувати? (форматування, політики іменування, обробка null-значень тощо)

       // Наприклад, можемо серіалізувати одразу в файл, не зберігаючи JSON у рядку:
        public void Example3()
        {
            Player player = new Player
            {
                Name = "Hero",
                Level = 10,
                Inventory = ["Sword", "Shield", "Potion"]
            };
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            using (FileStream fs = new FileStream("player_stream.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fs, player, options);
            }
        }

        // Ще є атрибути для налаштування серіалізації на рівні класу або властивості, такі як [JsonPropertyName], [JsonIgnore], [JsonConverter] тощо,
        // які дозволяють контролювати, як конкретні поля або властивості будуть серіалізовані або десеріалізовані.
    }

}
