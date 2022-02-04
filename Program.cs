using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static public List<char> Characters = new List<char>("abcdefghijklmnopqrstuvwxyz");
        static void Main(string[] args)
        {
            string key = "hey";
            string text = "hello, world!";
            Console.WriteLine($"Text: {text}");

            string cryptText = Crypt(key, text);
            Console.WriteLine($"Crypt Text: {cryptText}");

            string decryptText = Decrypt(key, cryptText);
            Console.WriteLine($"Decrypt Text: {decryptText}");

            Console.ReadKey();
        }

        static String Crypt(String key, String text)
        {
            string newText = "";
            int letterPosition = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (Characters.Contains(letter))
                {
                    int idLetter = Characters.FindIndex(x => x == letter);
                    int idKeyLetter = Characters.FindIndex(x => x == key[letterPosition % key.Length]);
                    int id = (idLetter + idKeyLetter) % Characters.Count;

                    newText += Characters[(idLetter + idKeyLetter) % Characters.Count];
                    letterPosition++;
                }
                else newText += letter;
            }

            return newText;
        }

        static String Decrypt(String key, String text)
        {
            string newText = "";
            int letterPosition = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (Characters.Contains(letter))
                {
                    int idLetter = Characters.FindIndex(x => x == letter);
                    int idKeyLetter = Characters.FindIndex(x => x == key[letterPosition % key.Length]);
                    int id = (idLetter - idKeyLetter) < 0 ? idLetter + (Characters.Count - idKeyLetter) : (idLetter - idKeyLetter) % Characters.Count;

                    newText += Characters[id];
                    letterPosition++;
                }
                else newText += letter;
            }

            return newText;
        }
    }
}
