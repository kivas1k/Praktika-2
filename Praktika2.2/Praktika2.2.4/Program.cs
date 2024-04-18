using System;

class Counter
{
    public int Count { get; set; }

    public Counter()
    {
        Count = 0;
    }

    public Counter(int initialValue)
    {
        Count = initialValue;
    }

    public void Incerement()
    {
        Count++;
    }

    public void Decrement()
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