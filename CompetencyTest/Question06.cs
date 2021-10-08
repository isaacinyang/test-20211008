using System;
using System.Collections.Generic;

namespace CompetencyTest
{
    /// <summary>
    /// Bubble Sort - in ascending order
    /// </summary>
    class Question06
    {
        public static int[] RunBubbleSort(int[] arr)
        {
            var arrLength = arr.Length;

            for (int i = 0; i < arrLength - 1; i++)
            {
                for (int j = 0; j < arrLength - 1 - i; j++)
                {
                    if (arr[j] <= arr[j + 1])
                        continue;

                    //  swap values here
                    var tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                }
            }

            return arr;
        }
    }
}