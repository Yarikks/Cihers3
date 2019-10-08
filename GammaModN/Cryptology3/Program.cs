using System;

namespace Cryptology3
{
    internal class Program
    {
        private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";

        private static void Main(string[] args)
        {
            string phrase = "This text ciphered";
            
            string key = "yaroslavssciphered";

            Console.WriteLine("Encrypt: " + Gamma(phrase, key, alphabet.Length));
            Console.ReadLine();
        }

        static string Gamma(string phrase, string key, int N)
        {
            
            string result = "";
            int[,] table = new int[4, phrase.Length];

            for (int i = 0; i < phrase.Length; i++)
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (Convert.ToString(key[i]).ToLower() == Convert.ToString(alphabet[j]).ToLower())
                        table[1, i] = j;
                    if (Convert.ToString(phrase[i]).ToLower() == Convert.ToString(alphabet[j]).ToLower())
                        table[0, i] = j;
                }

            for (int i = 0; i < key.Length; i++)
            {
                table[2, i] = (table[0, i] + table[1, i]) % N;
                result += alphabet[table[2, i]];
            }

            return result;
        }
    }
}

