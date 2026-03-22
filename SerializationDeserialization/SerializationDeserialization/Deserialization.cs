using System.Text.Json;

namespace SerializationDeserialization
{
    // Десеріалізація — це процес перетворення послідовності байтів або текстового формату назад в об’єкт.
    // JSON → об’єкт

    // У C# є вбудовані механізми для десеріалізації, такі як System.Text.Json та Newtonsoft.Json, які дозволяють легко перетворювати JSON в об’єкти та навпаки.

    internal class Deserialization
    {
        public Player? LoadPlayer()
        {
            string json = File.ReadAllText("player.json");
            Player? player = JsonSerializer.Deserialize<Player>(json);
            return player;
        }

        public void Example()
        {
            Player? player = LoadPlayer();
            if (player != null)
            {
                player.ShowInfo();
                Console.WriteLine("sdrh");
                
            }
            else
            {
                Console.WriteLine("Failed to load player.");
            }
            
        }
    }
}
