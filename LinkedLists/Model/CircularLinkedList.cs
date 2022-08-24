using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Model
{
    /// <summary>
    /// Кольцевой список.
    /// </summary>
    /// <typeparam name="T">Тип элементов.</typeparam>
    public class CircularLinkedList<T> :IEnumerable
    {
        /// <summary>
        /// Головной элемент.
        /// </summary>
        public DuplexItem<T> Head { get; private set; }

        /// <summary>
        /// Размер.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Создать пустой список.
        /// </summary>
        public CircularLinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Создать новый список.
        /// </summary>
        /// <param name="data"></param>
        public CircularLinkedList(T data)
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
            Head.Next = Head;
            Head.Previous = Head;
            Count++;
        }

        /// <summary>
        /// Очистить список.
        /// </summary>
        public void Clear()
        {
            Head = null;
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
