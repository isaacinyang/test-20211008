using System;

namespace CompetencyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test01();
            Test02();
            Test03();
            Test04();
            Test05();
            Test06();
            Test07();
            Test08();
            Test09();
            Test10();
        }

        static void Test01()
        {
            Console.Write("Enter a word: ");

            var word = Console.ReadLine();
            var result = Question01.Run(word);
            Console.WriteLine(result);
        }

        static void Test02()
        {
            Console.Write("Enter a word: ");

            var word = Console.ReadLine();
            var result = Question02.Run(word);
            Console.WriteLine(result);
        }

        static void Test03()
        {
            var result = Question03.Run(10);
            Console.WriteLine(result);
        }

        static void Test04()
        {
            var result = Question04.Run(30);
            Console.WriteLine(result);
        }

        static void Test05()
        {
            foreach (var word in new[] { "isaac", "madam", "Madam", "racecar", "abba" })
            {
                var result = Question05.Run(word);
                Console.WriteLine(result);
            }
        }

        private static void Test06()
        {
            var arr = new int[] { 64, 34, 25, 12, 22, 11, 90 };
            var result = Question06.RunBubbleSort(arr);

            Console.WriteLine("The final array is:");
            Console.WriteLine(string.Join(",", result));
        }

        public static void Test07()
        {
            var arr1 = new int[] { 25, 12, 22, 11, 90 };
            var arr2 = new int[] { 64, 34, 25, 12, 22 };
            var diff = Question07.GetDifferences(arr1, arr2);

            Console.WriteLine("The difference array is:");
            Console.WriteLine(string.Join(",", diff));
        }

        public static void Test08()
        {
            int[,] arr = { { 16, 20 }, { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            var sum = Question08.GetSubArraySum(arr);
            Console.WriteLine("The final array is:");
            Console.WriteLine(string.Join(",", sum));
        }

        public static void Test09()
        {
            foreach (var ip in new[]{ "10.105.400.11","0.0.0.0", "255.255.255.255", "255.255.255.256", " 255.255.255.255", "a.b.c.d", "100.200.300  .200", "100.200,300  .200" })
            {
                var response = Question09.Test(ip);
                Console.WriteLine($"{ip} is {response}");
            }
        }

        public static void Test10()
        {
            var csvPath = @"C:\Users\Isaac\Desktop\uct_commerce_users.csv";
            Question10.Run(csvPath);
        }
    }
}
