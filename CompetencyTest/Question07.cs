using System;

namespace CompetencyTest
{
    class Question07
    {
        public static int[] GetDifferences(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
                throw new Exception("One or both arrays are NULL");

            if (arr1.Length != arr2.Length)
                throw new Exception("Both arrays/list are of different Lengths");

            var arrLength = arr1.Length;

            var diff = new int[arrLength];

            for (int i = 0; i < arrLength; i++)
            {
                diff[i] = arr1[i] - arr2[i];
            }

            return diff;
        }
    }
}