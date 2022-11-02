using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

           ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            var sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(bytesFilePath))
            {
                byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
                var bytesList = new List<string>();

                while (!reader.EndOfStream)
                    bytesList.Add(reader.ReadLine());

                foreach (var item in fileBytes)
                {
                    if (bytesList.Contains(item.ToString()))
                        sb.AppendLine(item.ToString());
                }
            }

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
