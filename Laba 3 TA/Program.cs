using System;
using System.Collections.Generic;

class Key
{
    public string Stock { get; }
    public int DayOfYear { get; }

    public Key(string stock, int dayOfYear)
    {
        Stock = stock;
        DayOfYear = dayOfYear;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Stock, DayOfYear);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Key other = (Key)obj;
        return Stock == other.Stock && DayOfYear == other.DayOfYear;
    }
}

class ImprovedHashTable
{
    private Dictionary<Key, double> dictionary;

    public ImprovedHashTable(int size)
    {
        dictionary = new Dictionary<Key, double>(size);
    }

    public void Put(Key key, double value)
    {
        dictionary[key] = value;
    }

    public double Get(Key key)
    {
        if (dictionary.TryGetValue(key, out double value))
        {
            return value;
        }
        else
        {
            throw new KeyNotFoundException("Key not found");
        }
    }

    public bool ContainsKey(Key key)
    {
        return dictionary.ContainsKey(key);
    }

    public double Remove(Key key)
    {
        if (dictionary.TryGetValue(key, out double value))
        {
            dictionary.Remove(key);
            return value;
        }
        else
        {
            throw new KeyNotFoundException("Key not found");
        }
    }

    public int Size()
    {
        return dictionary.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ImprovedHashTable ht = new ImprovedHashTable(1024);
        int choice;
        do
        {
            Console.WriteLine("1. Покласти значення за ключем в таблицю");
            Console.WriteLine("2. Взяти значення з таблиці за ключем");
            Console.WriteLine("3. Перевірити чи є даний ключ в таблиці");
            Console.WriteLine("4. Видалити елемент з таблиці за ключем");
            Console.WriteLine("5. Повернути кількість елементів в хеш-таблиці.");
            Console.WriteLine("Для виходу з програми введіть 0");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Введіть день: ");
                    int day1 = int.Parse(Console.ReadLine());
                    Console.Write("Введіть місяць: ");
                    string month1 = Console.ReadLine();
                    Console.Write("Введіть число: ");
                    int number = int.Parse(Console.ReadLine());
                    ht.Put(new Key(month1, day1), number);
                    break;
                case 2:
                    Console.Write("Введіть день: ");
                    int day2 = int.Parse(Console.ReadLine());
                    Console.Write("Введіть місяць: ");
                    string month2 = Console.ReadLine();
                    double metasPrice = ht.Get(new Key(month2, day2));
                    Console.WriteLine("Ціна Meta: " + metasPrice);
                    break;
                case 3:
                    Console.Write("Введіть день: ");
                    int day3 = int.Parse(Console.ReadLine());
                    Console.Write("Введіть місяць: ");
                    string month3 = Console.ReadLine();
                    bool t = ht.ContainsKey(new Key(month3, day3));
                    Console.WriteLine(t);
                    break;
                case 4:
                    Console.Write("Введіть день: ");
                    int day4 = int.Parse(Console.ReadLine());
                    Console.Write("Введіть місяць: ");
                    string month4 = Console.ReadLine();
                    ht.Remove(new Key(month4, day4));
                    break;
                case 5:
                    int n = ht.Size();
                    Console.WriteLine(n);
                    break;
                case 0:
                    Console.WriteLine("Зараз завершимо, тільки натисніть будь ласка ще раз Enter");
                    break;
                default:
                    Console.WriteLine("Команда ``{0}'' не розпізнана. Зробіть, будь ласка, вибір із 1, 2, 3, 0.", choice);
                    break;
            }
        } while (choice != 0);

        ht.Put(new Key("APPL", 223), 180.0);
        ht.Put(new Key("META", 300), 160.34);

        try
        {
            double metaPrice = ht.Get(new Key("META", 300));
            Console.WriteLine("Meta Price: " + metaPrice);
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
