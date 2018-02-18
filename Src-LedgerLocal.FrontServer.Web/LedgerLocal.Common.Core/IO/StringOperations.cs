using System;
using System.IO;

namespace LedgerLocal.Common.Core
{
    public class StringOperations
    {
        public static byte[] ConvertStringToBytes(string input)
        {
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream))
            {
                writer.Write(input);
                writer.Flush();
            }

            return stream.ToArray();
        }

        public static string ConvertBytesToString(byte[] bytes)
        {
            var output = String.Empty;
            var stream = new MemoryStream(bytes) {Position = 0};

            using (var reader = new StreamReader(stream))
            {
                output = reader.ReadToEnd();
            }

            return output;
        }
    }
}
