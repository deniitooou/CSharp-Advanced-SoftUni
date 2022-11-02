namespace CopyDirectory
{
    using System.IO;

    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Users\User 1\Desktop\Streams, Files and Directories - Exercises\05. Copy Directory\CopyBinaryFile";
            string outputPath = @"C:\Users\User 1\Desktop\Streams, Files and Directories - Exercises\05. Copy Directory\CopyHere";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            Directory.CreateDirectory(outputPath);

            string[] files = Directory.GetFiles(inputPath);

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);

                string destination = Path.Combine(outputPath, fileName);

                File.Copy(file, destination);
            }
        }
    }
}
