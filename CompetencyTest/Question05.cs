using System;

namespace CompetencyTest
{
    class Question05
    {
        public static string Run(string word)
        {
            var isPalidrome = IsPalidrome(word);

            if (isPalidrome)
                return ($"\"{word}\" is a palidrome");
            else
                return ($"\"{word}\" is NOT a palidrome");
        }

        private static bool IsPalidrome(string word)
        {
            if (word == null || string.IsNullOrWhiteSpace(word))
                return false;

            // We compare both ends of the word until there is a mismatch
            for (int i = 0; i < word.Length / 2; i++)
            {
                var a = word[i];
                var b = word[word.Length - i - 1];

                if (a != b)
                    return false;
            }

            return true;
        }
    }
}
