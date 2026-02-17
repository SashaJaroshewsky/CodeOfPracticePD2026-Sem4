namespace FileIO
{
    internal class Filecopier
    {
        public void CopyFile(string sourcePath, string destinationPath)
        {
            // Використовуємо FileStream для копіювання файлу
            using FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            using FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);
            sourceStream.CopyTo(destinationStream);
        }
    }
}
