using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListTut
{

    class MyList<T> : IEnumerable<T>
    {

        private T[] arr;

        public void Add(T item)
        {
            if (arr == null)
            {

                arr = new T[] { item };

            }
            else
            {

                T[] temp = new T[arr.Length + 1];

                for (int i = 0; i < arr.Length; i++)
                {

                    temp[i] = arr[i];

                }

                temp[arr.Length] = item;

                arr = temp;

            }
        }

        public void Remove(T item)
        {

            T[] temp = new T[arr.Length - 1];

            for (int i = 0; i < temp.Length; i++)
            {

                if (arr[i].Equals(item))
                {

                    temp[i] = arr[i + 1];

                    continue; //переход к след. итерации

                }

                temp[i] = arr[i];

            }

            arr = temp;

        }

        public T this[int i]
        {

            get{ return arr[i]; }

        }

        //Возможность использовать foreach

        public IEnumerator<T> GetEnumerator()

        {
            foreach (T item in arr)
            {

                yield return item;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return GetEnumerator();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> lst = new MyList<int>();

            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Remove(3);
            lst.Add(4);

            foreach (int i in lst)
            {

                Console.WriteLine(i);

            }

            Console.ReadLine();
        }
    }
}
