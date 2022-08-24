using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Model
{
    /// <summary>
    /// Двусвязный список.
    /// </summary>
    /// <typeparam name="T">Данные элементов.</typeparam>
    public class DuplexLinkedList<T> : IEnumerable
    {
        /// <summary>
        /// Головной элемент.
        /// </summary>
        public DuplexItem<T> Head { get; private set; }

        /// <summary>
        /// Хвостовой элемент.
        /// </summary>
        public DuplexItem<T> Tail { get; private set; }

        /// <summary>
        /// Размер.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// СОздать пустой список.
        /// </summary>
        public DuplexLinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Создать новый список.
        /// </summary>
        /// <param name="data">Данные нового элемента.</param>
        public DuplexLinkedList(T data)
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

            var item = new DuplexItem<T>(data);
            Head = item;
            Tail = item;
            Count++;
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

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="data">Данные удаляемого элемента.</param>
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

        /// <summary>
        /// Реверсировать список.
        /// </summary>
        /// <returns>Реверсированный двусвязный список.</returns>
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
