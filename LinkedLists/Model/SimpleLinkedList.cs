using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Model
{
    /// <summary>
    /// Односвязный список.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleLinkedList<T> : IEnumerable
    {
        /// <summary>
        /// Головной элемент.
        /// </summary>
        public Item<T> Head { get; private set; }

        /// <summary>
        /// Хвостовой элемент.
        /// </summary>
        public Item<T> Tail { get; private set; }

        /// <summary>
        /// Размер.
        /// </summary>
        public int Count { get; private set; } 

        /// <summary>
        /// Создать пустой список.
        /// </summary>
        public SimpleLinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Очистить список.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Создать новый список.
        /// </summary>
        /// <param name="data">Данные нового элемента.</param>
        public SimpleLinkedList(T data)
        {
            if (data.Equals(default(T)))
            {
                throw new ArgumentNullException(nameof(data), "Элемент не может быть нулевым");
            }

            SetHeadAndTail(data);
        }

        /// <summary>
        /// Добавить элемент в качестве головного и хвостового.
        /// </summary>
        /// <param name="data">Данные нового элемента.</param>
        private void SetHeadAndTail(T data)
        {
            if (data.Equals(default(T)))
            {
                throw new ArgumentNullException(nameof(data), "Элемент не может быть нулевым");
            }

            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count++;
        }

        /// <summary>
        /// Добавить элемент.
        /// </summary>
        /// <param name="data">Данные нового элемента.</param>
        public void Add(T data)
        {
            if (data.Equals(default(T)))
            {
                throw new ArgumentNullException(nameof(data), "Элемент не может быть нулевым");
            }

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

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="data">Удаляемый элемент.</param>
        public void Delete(T data)
        {
            if (data.Equals(default(T)))
            {
                throw new ArgumentNullException(nameof(data), "Элемент не может быть нулевым");
            }

            if (Count == 1)
            {
                Clear();
                return;
            }

            var previous = Head;
            var current = Head.Next;
            while (current != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }
                if (current.Data.Equals(data))
                {
                    if (Tail.Data.Equals(data))
                    {
                        Tail = previous;
                        Tail.Next = null;
                        Count--;
                        return;
                    }
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
