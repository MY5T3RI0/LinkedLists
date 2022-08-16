using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Model
{
    public class DuplexLinkedList<T> : IEnumerable
    {
        public DuplexItem<T> Head { get; private set; }

        public DuplexItem<T> Tail { get; private set; }

        public int Count { get; private set; }

        public DuplexLinkedList()
        {
            Clear();
        }

        public DuplexLinkedList(T data)
        {
            SetHeadAndTail(data);
        }
        private void SetHeadAndTail(T data)
        {
            var item = new DuplexItem<T>(data);
            Head = item;
            Tail = item;
            Count++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Add(T data)
        {
            if (Count > 0)
            {
                var item = new DuplexItem<T>(data);

                item.Previous = Tail;
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

            var current = Head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (Head.Data.Equals(data))
                    {
                        Head = Head.Next;
                        Head.Previous = null;
                        Count--;
                        return;
                    }
                    if (Tail.Data.Equals(data))
                    {
                        Tail = Tail.Previous;
                        Tail.Next = null;
                        Count--;
                        return;
                    }
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return;
                }

                current = current.Next;
            }
        }

        public DuplexLinkedList<T> Reverse()
        {
            var NewList = new DuplexLinkedList<T>();

            if (Count > 0)
            {
                var current = Tail;

                while (current != null)
                {
                    NewList.Add(current.Data);
                    current = current.Previous;
                }
            }
            return NewList;

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
            return $"Двусвязный список с {Count} элементов";
        }
    }
}
