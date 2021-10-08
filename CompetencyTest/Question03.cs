using System;
using System.Collections.Generic;
using System.IO;

namespace CompetencyTest
{
    class Question03
    {
        public static string Run(int no = 10)
        {
            if (no <= 0)
                return null;

            var fibs = new List<int>() { 0, 1 };

            for (int i = fibs.Count; i < no; i++)
            {
                var newFib = fibs[i - 1] + fibs[i - 2];
                fibs.Add(newFib);
            }

            var sw = new StringWriter();
            sw.WriteLine($"The first {no} fibonacci numbers are:");
            sw.WriteLine(string.Join(", ", fibs));
            return sw.ToString();
        }
    }
}