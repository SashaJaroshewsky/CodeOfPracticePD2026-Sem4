using FileIO.WorkingWithTextFiles;

namespace FileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлюємо кодування для консолі, щоб коректно відображати українські символи

            //CreatingPipeFileStream creatingPipeFileStream = new CreatingPipeFileStream();
            //creatingPipeFileStream.CreateFileStream();
            FileInfoIO fileInfoIO = new FileInfoIO();
            fileInfoIO.FileInfoExample3();
        }
    }
}
