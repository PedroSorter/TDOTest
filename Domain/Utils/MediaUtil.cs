using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Utils
{
    public static class MediaUtil
    {
        public static byte[] ReadStream(Stream input)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static string SafeConvertToBase64(byte[] image)
        {
            var base64String = Convert.ToBase64String(image, 0, image.Length);
            return $"data:image/png;base64,{base64String}";
        }

        public static string GetDataHeader(string base64String)
        {
            var data = base64String.Substring(0, 3).ToUpper();

            string mimeType;

            switch (data)
            {
                case "IVB":
                    mimeType = ".png";
                    break;
                case "/9J":
                case "FFD":
                    mimeType = ".jpg";
                    break;
                case "R0l":
                    mimeType = ".gif";
                    break;
                case "Qk0":
                    mimeType = ".bmp";
                    break;
                default:
                    mimeType = ".jpeg";
                    break;
            }

            return $"data:{mimeType};base64,";
        }

        public static byte[] ReadToEnd(Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}
