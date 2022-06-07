using CustomCollectionLibrary;
using System;

namespace CustomCollectionLibraryFixed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "11", "22", "33", "44" };
            Console.Write("Start list: ");
            PrintList(list);

            Console.WriteLine();

            Console.WriteLine("List contains \"44\": " + list.Contains("44"));
            Console.WriteLine("List contains \"44\": " + list.Contains("54"));

            Console.WriteLine();

            list.AddFirst("00");
            list.AddLast("66");
            Console.Write("AddFirst(\"00\") and AddLast(\"66\"): ");
            PrintList(list);

            Console.WriteLine();

            var temp1 = list.GetCustomLinkedListNodeByIndex(list.Count-1);
            list.AddBefore(temp1, "55");
            Console.Write("AddBefore(GetNodeByIndex(list.Count-1), \"55\"): ");
            PrintList(list);

            Console.WriteLine();

            list.Remove("44");
            Console.Write("Remove(\"44\"): ");
            PrintList(list);

            Console.WriteLine();

            var array = new string[list.Count];
            list.CopyTo(array, list.Count - 1);
            Console.Write("Copied array: ");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine();

            list.Clear();
            Console.WriteLine("Cleared list:");
            PrintList(list);
        }
        public static void PrintList(CustomLinkedList<string> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
