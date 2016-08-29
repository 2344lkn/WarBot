using System;
using System.Collections.Generic;

namespace WarBot
{
    public class PolyCrypt
    {
        #region Polymorphic Encrypt Text

        public static string polyEncryptTxt(string text, string pass)
        {
            Random R = new Random();                    // Random Number Generator
            int kl = 0;                                 // Key Length
            char[] txtAr = text.ToCharArray();          // Text Array
            char[] pwdAr = pass.ToCharArray();          // Password Array
            char[] fVal = new char[text.Length + 1];    // Final Val
            int Rnd = R.Next(100, 220);                 // Random between 100-220

            // for loop
            for (int plyCrypt = 0; plyCrypt < text.Length; plyCrypt++)
            {
                if (kl >= pwdAr.Length)
                    kl = 0;

                int tVal = (int)txtAr[plyCrypt];
                int pVal = (int)pwdAr[kl];
                int cVal = tVal + pVal + Rnd;
                fVal[plyCrypt] = Convert.ToChar(cVal);
                kl++;
            }

            fVal[text.Length] = (char)Rnd;
            string plyStr = new string(fVal);
            Console.WriteLine("Encrypted:");
            Console.WriteLine(plyStr);
            return plyStr;
        }

        #endregion

        #region Polymorphic Decrypt Text

        public static string polyDecryptTxt(string text, string pass)
        {
            string polyDec = "0";
            try
            {
                char[] txtAr = text.ToCharArray();
                char[] pwdAr = pass.ToCharArray();
                char[] fVal = new char[text.Length - 1];
                int rVal = txtAr[text.Length - 1];
                int kl = 0;

                for (int plyCrypt = 0; plyCrypt < text.Length; plyCrypt++)
                {
                    if (plyCrypt >= text.Length - 1)
                        continue;
                    if (kl >= pwdAr.Length)
                        kl = 0;
                    int tVal = txtAr[plyCrypt];
                    int pVal = pwdAr[kl];
                    int cVal = tVal - rVal - pVal;
                    fVal[plyCrypt] = Convert.ToChar(cVal);
                    kl++;
                }

                string plyStr = new string(fVal);
                Console.WriteLine("Decrypted:");
                Console.WriteLine(plyStr);
                return plyStr;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Red;
            }

            return polyDec;
        }

        #endregion
    }
}
