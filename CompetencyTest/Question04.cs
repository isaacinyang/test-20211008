using System;
using System.Collections.Generic;
using System.IO;

namespace CompetencyTest
{
    class Question04
    {
        public static string Run(int no)
        {
            if (no <= 0) return null;

            var factors = new List<int>();

            var i = 1;
            //  check through all numbers less than the Square Root of the given number
            while (i * i < no)
            {
                //  if no remainder is zero, then get the two factors
                if (no % i == 0)
                {
                    factors.Add(i);
                    factors.Add(no / i);
                }

                i++;
            }

            //  for perfect squares...
            if (i * i == no)
                factors.Add(i);

            factors.Sort();

            //  display the factors
            var sw = new StringWriter();
            sw.WriteLine($"The factors of {no} are:");
            sw.WriteLine(string.Join(", ", factors));
            return sw.ToString();
        }
    }
}
