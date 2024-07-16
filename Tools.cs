using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace meituan
{
    internal static class Tools
    {



        public static byte[] filldata(byte[] inputdata)
        {
            int len = inputdata.Length;

            int mod = len % 0x10;

            int fill = 0x10 - mod;

            PackOperate Operate = new PackOperate();

            Operate.SetBytes(inputdata);

            for (int i = 0; i < fill; i++)
            {

                Operate.SetByte(fill);
            }


            return Operate.GetAll();

        }
        public static byte[] AesEncrypt(byte[] src, byte[] key, byte[] iv, string cipher, PaddingMode padding)
        {
            byte[] resultArray = new byte[0];

            Aes aes = Aes.Create();

            aes.Key = key;

            switch (cipher)
            {
                case "CBC":
                    resultArray = aes.EncryptCbc(src, iv, padding);
                    break;
                case "ECB":
                    resultArray = aes.EncryptEcb(src, padding);

                    break;
                case "CFB":
                    resultArray = aes.EncryptCfb(src, iv, padding);
                    break;
            }
            return resultArray;
        }

        public static byte[] AesDecrypt(byte[] src, byte[] key, byte[] iv, string cipher, PaddingMode padding)
        {
            byte[] resultArray = new byte[0];

            Aes aes = Aes.Create();

            aes.Key = key;

            switch (cipher)
            {


                case "CBC":
                    resultArray = aes.DecryptCbc(src, iv, padding);
                    break;
                case "ECB":
                    resultArray = aes.DecryptEcb(src, padding);
                    break;

                case "CFB":
                    resultArray = aes.DecryptCfb(src, iv, padding);
                    break;

            }
            return resultArray;
        }


















        public static byte[] sha1(this byte[] sourceBytes)
        {

            using (SHA1 sha1Hash = SHA1.Create())
            {
                //从字符串到字节数组


                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);

        
                return hashBytes;

            }
        }



        public static long CRC32(this byte[] sourceBytes)
        {

            CRC32 crc = new CRC32();

            crc.Reset();

            crc.Update(sourceBytes);

            return crc.Value;

        }


    }
}
