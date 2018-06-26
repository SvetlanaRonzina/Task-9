using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_9
{
    class Item
    {
        public int Data;
        public Item Next;
    }


    class Program
    {
        static Item positiveList = null;
        static Item negativeList = null;
        static Item nullList = null;

        /// <summary>
        /// Добавляет число в начало списка, возвращает ссылку на список
        /// </summary>
        /// <param name="myList">список</param>
        /// <param name="number">число</param>
        /// <returns></returns>
        private static Item AddToStart(Item myList, int number)
        {
            return myList == null ? new Item { Data = number } : new Item { Data = number, Next = myList };
        }

        public static Item AddNewItem(int number)
        {
            if (number == 0)
            {
                nullList = AddToStart(nullList, number);

            }
        }

        private static Item AttachLists()
        {
            Attach(positiveList, nullList, negativeList);

            Attach(nullList, negativeList, positiveList);

            Attach(negativeList, positiveList, nullList);

            if (positiveList != null)
                return positiveList;

            if (nullList != null)
                return nullList;

            return negativeList;
        }

        private static void Attach(Item firstList, Item secondList, Item thirdList)
        {
            if (firstList != null)
            {
                var last = LastItem(firstList);

                if (secondList != null)
                    last.Next = secondList;
                else
                {
                    last.Next = thirdList ?? firstList;
                }
            }
        }

        private static Item LastItem(Item list)
        {
            var cursor = list;
            while (cursor.Next != null)
                cursor = cursor.Next;

            return cursor;
        }

        public static void Main(string[] args)
        {
            var isCorrect = int.TryParse(Console.ReadLine(), out var N);
            if (!isCorrect || N < 1)
                return;

            var file = new StreamReader("input.txt");
            for (var i = 0; i < N; i++)
            {
                if (int.TryParse(file.ReadLine(), out var data))
                {
                    if (data == 0)
                        nullList = AddToStart(nullList, data);

                    if (data > 0)
                        positiveList = AddToStart(positiveList, data);

                    if (data < 0)
                        negativeList = AddToStart(negativeList, data);
                }

            }

            var head = AttachLists();
        }
    }
}