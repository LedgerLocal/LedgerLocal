using System.IO;

namespace LedgerLocal.Common.Core
{
    public class StreamOperations
    {
        public static byte[] ConvertStreamToByteArray(Stream stream)
        {
            stream.Position = 0;
            using(var ms = new MemoryStream())
            {
                var buffer = new byte[1024];
                int bytes;

                while ((bytes = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytes);
                }

                return ms.ToArray();  
            }
        }

        public static Stream ConvertByteArrayToStream(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return ms;
            }
        }
    }
}

