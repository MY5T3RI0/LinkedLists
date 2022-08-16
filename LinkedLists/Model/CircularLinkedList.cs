using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Model
{
    public class CircularLinkedList<T> :IEnumerable
    {

        public DuplexItem<T> Head { get; private set; }

        public int Count { get; private set; }

        public CircularLinkedList()
        {
            Clear();
        }

        public CircularLinkedList(T data)
        {
            SetHeadAndTail(data);
        }
        private void SetHeadAndTail(T data)
        {
            var item = new DuplexItem<T>(data);
            Head = item;
            Head.Next = Head;
            Head.Previous = Head;
            Count++;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public void Add(T data)
        {
            if (Count == 0)
            {
                SetHeadAndTail(data);
                return;
            }

            var item = new DuplexItem<T>(data);

            item.Previous = Head.Previous;
            item.Next = Head;
            Head.Previous.Next = item;
            Head.Previous = item;
            Count++;
        }

        public void Delete(T data)
        {
            if (Count == 1)
            {
                Clear();
                return;
            }

            var current = Head.Next;

            for (int i = 0; i < Count; i++)
            {
                if (current.Data.Equals(data))
                {
                    if (Head.Data.Equals(data))
                    {
                        Head = Head.Next;
                    }       
                    current.Next.Previous = current.Previous;
                    current.Previous.Next = current.Next;
                    Count--;
                    return;
                }

                current = current.Next;
            }
            
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;

            for (int i = 0; i < Count; i++)
            {
                yield return current.Data;
                current = current.Next; 
            }
            
        }

        public override string ToString()
        {
            return $"Кольцевой список с {Count} элементов";
        }

    }
}
