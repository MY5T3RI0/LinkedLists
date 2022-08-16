using LinkedLists.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var NewList = new SimpleLinkedList<int>();

            NewList.Add(1);
            NewList.Add(2);
            NewList.Add(3);
            NewList.Add(4);
            NewList.Add(5);

            foreach (var item in NewList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            NewList.Delete(3);

            foreach (var item in NewList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
