using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CompetencyTest
{
    /// <summary>
    /// Counts the number of vowels and consonants in a given word
    /// </summary>
    public class Question01
    {
        public static string Run(string word)
        {
            //  make all the letters in the lowercase: a - z
            var str = word.ToLower();

            var vowels = 0;
            var consonants = 0;

            foreach (char c in str)
            {
                //  filter out all characters outside of the a - z range
                if (c < 'a' || c > 'z')
                    continue;

                if (Vowels.Contains(c))
                    vowels++;
                else
                    consonants++;
            }

            var sw = new StringWriter();
            sw.WriteLine($"The number of vowels in \"{word}\" is {vowels}");
            sw.WriteLine($"The number of consonants in \"{word}\" is {consonants}");
            return sw.ToString();
        }

        private static readonly char[] Vowels = new char[] {'a', 'e', 'i', 'o', 'u'};
    }
}