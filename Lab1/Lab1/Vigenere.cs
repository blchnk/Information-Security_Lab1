using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    public class VigenereCipher
    {
        public char[] alphabet;
        public int N;

        public VigenereCipher() { }

        public VigenereCipher(char[] alphabet, int N)
        {
            this.alphabet = alphabet;
            this.N = N;
        }

        public string Encrypt(string inputText, string keyword)
        {
            inputText = inputText.ToLower();
            keyword = keyword.ToLower();

            string result = "";

            int keywordIndex = 0;

            foreach (char symbol in inputText)
            {
                int c = (Array.IndexOf(alphabet, symbol) +
                         Array.IndexOf(alphabet, keyword[keywordIndex])) % N;

                if (Array.IndexOf(alphabet, symbol) == -1)
                {
                    result += symbol;
                }
                else
                {
                    result += alphabet[c];
                    keywordIndex++;
                }

                if ((keywordIndex + 1) == keyword.Length) keywordIndex = 0;
            }

            return result;
        }

        public string Decrypt(string outputText, string keyword)
        {
            outputText = outputText.ToLower();
            keyword = keyword.ToLower();

            string result = "";

            int keywordIndex = 0;

            foreach (char symbol in outputText)
            {
                int m = (Array.IndexOf(alphabet, symbol) + N -
                         Array.IndexOf(alphabet, keyword[keywordIndex])) % N;

                if (Array.IndexOf(alphabet, symbol) == -1)
                {
                    result += symbol;
                }
                else
                {
                    result += alphabet[m];
                    keywordIndex++;
                }


                if ((keywordIndex + 1) == keyword.Length) keywordIndex = 0;
            }

            return result;
        }

        public string RandomKeywordGenerator(int length)
        {
            Random rnd = new Random();
            string result = "";

            for (int i = 0; i <= length; i++)
            {
                result += rnd.Next(0, length);
            }

            return result;
        }


        public string ReadFile(string path)
        {
            string result = "";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public void WriteFile(string text, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
