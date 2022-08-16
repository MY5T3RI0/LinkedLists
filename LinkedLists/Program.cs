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
            #region LinkedList
            var SimpleList = new SimpleLinkedList<int>();

            SimpleList.Add(1);
            SimpleList.Add(2);
            SimpleList.Add(3);
            SimpleList.Add(4);
            SimpleList.Add(5);

            Console.WriteLine(SimpleList);

            foreach (var item in SimpleList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            SimpleList.Delete(1);
            SimpleList.Delete(5);

            foreach (var item in SimpleList)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region DuplexList
            var DuplexList = new DuplexLinkedList<int>();

            DuplexList.Add(1);
            DuplexList.Add(2);
            DuplexList.Add(3);
            DuplexList.Add(4);
            DuplexList.Add(5);

            Console.WriteLine(DuplexList);

            foreach (var item in DuplexList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            DuplexList.Delete(5);
            DuplexList.Delete(1);
            DuplexList.Delete(3);

            foreach (var item in DuplexList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var ReverseList = DuplexList.Reverse();

            foreach (var item in ReverseList)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region CircularList
            var CircularList = new CircularLinkedList<int>();

            CircularList.Add(1);
            CircularList.Add(2);
            CircularList.Add(3);
            CircularList.Add(4);
            CircularList.Add(5);

            Console.WriteLine(CircularList);

            foreach (var item in CircularList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            CircularList.Delete(1);
            CircularList.Delete(3);

            foreach (var item in CircularList)
            {
                Console.WriteLine(item);
            } 
            #endregion

            Console.ReadLine();
        }
    }
}
