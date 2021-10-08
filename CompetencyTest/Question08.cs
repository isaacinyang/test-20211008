using System;
using System.Linq;

namespace CompetencyTest
{
    class Question08
    {
        public static int[] GetSubArraySum(int[,] arr)
        {
            var sum = new int[arr.GetLength(0)];

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    sum[i] += arr[i, j];
                }
            }

            return sum;
        }
    }
}