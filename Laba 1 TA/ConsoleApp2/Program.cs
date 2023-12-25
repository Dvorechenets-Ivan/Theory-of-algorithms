using System;
using System.Collections.Generic;

namespace Lab1
{
    class Queue<T>
    {
        private List<T> elements;

        public Queue()
        {
            elements = new List<T>();
        }

        public void Enqueue(T item)
        {
            elements.Add(item);
        }

        public T Dequeue()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T dequeuedItem = elements[0];
            elements.RemoveAt(0);
            return dequeuedItem;
        }

        public int Size()
        {
            return elements.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int choice;
            do
            {
                Console.WriteLine("1.Додати елемент в чергу");
                Console.WriteLine("2.Вивести всі елементи з черги");
                Console.WriteLine("3.Вивести один елемент з черги");
                Console.WriteLine("4.Кількість елементів у черзі");
                Console.WriteLine("Для виходу з програми введіть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введіть елемент який додати до черги");
                        int n = int.Parse(Console.ReadLine());
                        queue.Enqueue(n);
                        break;
                    case 2:
                        int f = queue.Size();
                        for (int i = 0; i < f; i++)
                        {
                            Console.WriteLine(queue.Dequeue());
                        }
                        break;
                    case 3:
                        Console.WriteLine(queue.Dequeue());
                        break;
                    case 4:
                        Console.WriteLine("Кількість елементів у черзі: " + queue.Size());
                        break;
                    case 0:
                        Console.WriteLine("Зараз завершимо, тільки натисніть будь ласка ще раз Enter");
                        break;
                    default:
                        Console.WriteLine("Команда ``{0}'' не розпізнана. Зробіть, будь ласка, вибір із 1, 2, 3, 0.", choice);
                        break;
                }
            } while (choice != 0);
        }
    }
}
