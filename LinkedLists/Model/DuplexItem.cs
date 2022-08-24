using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Model
{
    /// <summary>
    /// Двусвязный элемент.
    /// </summary>
    /// <typeparam name="T">Тип элемента.</typeparam>
    public class DuplexItem<T>
    {
        /// <summary>
        /// Данные.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Ссылока на следующий элемент.
        /// </summary>
        public DuplexItem<T> Next { get; set; }

        /// <summary>
        /// Ссылка на предыдущий элемент.
        /// </summary>
        public DuplexItem<T> Previous { get; set; }

        /// <summary>
        /// Создать новый элемент.
        /// </summary>
        /// <param name="data">Данные нового элемента.</param>
        public DuplexItem(T data)
        {
            if (data.Equals(default(T)))
            {
                throw new ArgumentNullException(nameof(data), "Элемент не может быть нулевым");
            }

            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
