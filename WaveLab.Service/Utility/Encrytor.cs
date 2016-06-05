using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace WaveLab.Service.Utility
{
  public sealed class Encrytor
    {
      private static int[] sbox = new int[128];

      private static int[] key = new int[128];

        public static  string Encryt(string source)
        {
            string val,encryptedString;
            val = "";
            encryptedString = EnDeCrypt(source.ToUpper(), "pwd");
            for (int x = 1; x <= encryptedString.Length; x++)
            {
                string temp;
                temp = Convert.ToInt32(Convert.ToChar(encryptedString.Substring(x - 1, 1))).ToString("x4");
                val = val + temp.Substring(temp.Length - 2, 2);
            }
            return val;
        }

        private static string EnDeCrypt(string plainTxt, string source)
        {

            int temp, a, i, j, k, cipherby;
            string cipher,val;
            i = 0;
            j = 0;
            cipher = "";
            RC4Initialize(source);
            for(a=1;a<=plainTxt.Length;a++)
            {
                i = (i + 1) %128;
                j = (j + sbox[i]) % 128;
                temp = sbox[i];
                sbox[i] = sbox[j];
                sbox[j]= temp;
                k = sbox[(sbox[i] + sbox[j]) % 128];
                cipherby = Convert.ToInt32(Convert.ToChar(plainTxt.Substring(a-1, 1))) ^ k;
                cipher = cipher +Convert.ToChar( cipherby);
            }
            val = cipher;
            return val;
    
        }

        private static void RC4Initialize(string source)
        {
            int tempSwap, a, b, intLength;
            intLength = source.Length;
            for (a = 0; a <= 127; a++)
            {
                key[a] = Convert.ToInt32(Convert.ToChar(source.Substring(a % intLength, 1)));
                sbox[a] = a;

            }
            b = 0;
            for (a = 0; a <= 127; a++)
            {
                b = (b + sbox[a] + key[a]) % 128;
                tempSwap = sbox[a];
                sbox[a] = sbox[b];
                sbox[b] = tempSwap;
            }
        }

        public static string GenPassWord()
        {
            string passWord="";
            int number;
            char code;
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                number=random.Next();
                if (number % 2 == 0)
                {
                    code =(char)( '0' + (char)number % 10);
                }
                else
                {
                    code =(char)( 'a' + (char)number % 26);
                }
                passWord +=code.ToString();
            }
            return passWord;
        }
    }
}
