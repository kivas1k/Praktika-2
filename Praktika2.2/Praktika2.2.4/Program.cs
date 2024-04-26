using System;

class Counter
{
    public int Count { get; set; } // личная инфа счетчика

    public Counter()
    {
        Count = 0;
    }

    public Counter(int initialValue) // Конструктор с начальным значением для Count
    {
        Count = initialValue;
    }

    public void Incerement() // Метод для увеличения значения счетчика на 1
    {
        Count++;
    }

    public void Decrement() // Создаем первый объект Counter с начальным значением 0
    {
        Count--;
    }
}

class Program
{
    static void Main()
    {
        Counter counter1 = new Counter();

        Console.WriteLine($"Начало счетчика 1 >> {counter1.Count}");
        
        counter1.Incerement();

        Console.WriteLine($"Подсчет после >> {counter1.Count}");

        Counter counter2 = new Counter(10);

        Console.WriteLine($"Начало счетчика 2 >> {counter2.Count}");
        
        counter2.Decrement();

        Console.WriteLine($"Подсчет после >> {counter2.Count}");
    }
}