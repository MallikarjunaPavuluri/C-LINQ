using System;
using System.Linq;

namespace LinqTutorial
{
    class Program
    {
        public static void Main(String []args)
        {
            int[] Marks = new int[10] { 59,23,76,34,97,35,98,32,79,67};
            var Above_50 = from mark in Marks where mark > 50 select mark;
            var Below_50 = from mark in Marks.Where(mark=>mark<50) select mark;
            Console.WriteLine("Above 50 Marks:");
            foreach (var i in Above_50)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine($"\nFirst Element In Above List-:{Above_50.First()}");
            Console.WriteLine($"Sum of Marks-{Marks.Sum()}");
            Console.WriteLine($"Count of Marks-{Marks.Count()}");
            Console.WriteLine($"Avg of Marks-{Marks.Average()}");
            Console.WriteLine("\nBelow 50 Marks:");
            foreach (var i in Below_50)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine($"\nFirst Element In Above List-:{Below_50.First()}");
            var sort = from i1 in Marks.OrderBy(c=>c) select i1;
            Console.WriteLine("\nOrderBy Expression");
            foreach (var i_1 in sort)
            {
                Console.Write(i_1+"\t");
            }
            //----------------------------------------------------------------------------------------------------------------
            var sort1 = from i1 in sort.Reverse() select i1;
            Console.WriteLine("\nReverse Expression");
            foreach (var i_1 in sort1)
            {
                Console.Write(i_1 + "\t");
            }
            Console.WriteLine("\nRange Values ");
            var numbers = Enumerable.Range(1, 10)
                                 .Select(c => 10 + (3 * c));
            var letters = Enumerable.Range(1, 10)
                                  .Select(c => (char)('A' + c));
            foreach (var i_1 in numbers)
            {
                Console.Write(i_1 + "\t");
            }
            Console.WriteLine("\nLetters");
            foreach (var i_1 in letters)
            {
                Console.Write(i_1 + "\t");
            }
            Random rand = new Random();
            letters = Enumerable.Range(1, 10)
                                  .Select(c => (char)('A' + rand.Next(0,26)));
            Console.WriteLine("\nRandom Letters");
            foreach (var i_1 in letters)
            {
                Console.Write(i_1 + "\t");
            }
            Console.WriteLine("\nRepeated Letter");
            var repeat = Enumerable.Repeat('M', 10);
            foreach (var i_1 in repeat)
            {
                Console.Write(i_1 + "\t");
            }
            //----------------------------------------------------------------------------------------------------------------
            var com_num = Enumerable.Range(0, 10);
            Console.WriteLine("\nNo in the List");
            foreach (var i_1 in com_num)
            {
                Console.Write(i_1 + "\t");
            }
            var com_i3 = Enumerable.Range(0, 10).Select(c => (c * c * c));
            Console.WriteLine("\nNo in the List i3 Format");
            foreach (var i_1 in com_i3)
            {
                Console.Write(i_1 + "\t");
            }
            var intersect = Enumerable.Intersect(com_num, com_i3);
            Console.WriteLine("\nIntersection of Above Two is-");
            foreach (var i_1 in intersect)
            {
                Console.Write(i_1 + "\t");
            }
            var union = Enumerable.Union(com_num, com_i3);
            Console.WriteLine("\nUnion of Above Two is-");
            foreach (var i_1 in union)
            {
                Console.Write(i_1 + "\t");
            }
            var concat = Enumerable.Concat(com_num, com_i3);
            Console.WriteLine("\nConcat of Above Two is-");
            foreach (var i_1 in concat)
            {
                Console.Write(i_1 + "\t");
            }
            var except = Enumerable.Except(com_num, com_i3);
            Console.WriteLine("\nExcept of Above Two is-");
            foreach (var i_1 in except)
            {
                Console.Write(i_1 + "\t");
            }
        }
    }
}
