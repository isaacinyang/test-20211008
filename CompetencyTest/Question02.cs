using System;
using System.Collections.Generic;
using System.IO;

namespace CompetencyTest
{
    /// <summary>
    /// 
    /// </summary>
    class Question02
    {
        public static string Run(string word)
        {
            var dic = new Dictionary<char, int>();

            foreach (char c in word)
            {
                //  Based on your sample solution, I will be excluding all white spaces.
                if (char.IsWhiteSpace(c))
                    continue;

                if (dic.ContainsKey(c) == false)
                    dic[c] = 1;
                else
                    dic[c]++;
            }

            var sw = new StringWriter();

            foreach (var p in dic)
            {
                sw.WriteLine($"{p.Key} = {p.Value}");
            }

            return sw.ToString();
        }
    }
}