using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Model
{
    public class SimpleLinkedList<T> : IEnumerable
    {
        public Item<T> Head { get; private set; }

        public Item<T> Tail { get; private set; }

        public int Count { get; private set; } 

        public SimpleLinkedList()
        {
            Clear();
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public SimpleLinkedList(T data)
        {
            SetHeadAndTail(data);
        }

        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count++;
        }

        public void Add(T data)
        {
            if (Count > 0)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        public void Delete(T data)
        {
            if (Count == 1)
            {
                Clear();
                return;
            }

            var previous = Head;
            var current = Head.Next;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    Count--;
                    return;
                }

                previous = previous.Next;
                current = current.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            return $"Связный список с {Count} элементов";
        }
    }
}
