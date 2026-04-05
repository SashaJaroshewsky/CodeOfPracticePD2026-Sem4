namespace SerializationDeserialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Serialization serialization = new Serialization();
            //serialization.Example();

            Deserialization deserialization = new Deserialization();
            deserialization.Example();

            //serialization.Example2();
            //serialization.Example3();
        }
    }
}
