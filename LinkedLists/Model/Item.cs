using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Model
{
    /// <summary>
    /// Односвязный элемент.
    /// </summary>
    /// <typeparam name="T">Тип элемента.</typeparam>
    public class Item<T>
    {
        /// <summary>
        /// Данные.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Ссылка на следующий элемент.
        /// </summary>
        public Item<T> Next { get; set; }

        /// <summary>
        /// Создать новый элемент.
        /// </summary>
        /// <param name="data">Данные нового элемента.</param>
        public Item(T data)
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
