using System;

class Numbers
{
    public int Num1 { get; set; }
    public int Num2 { get; set; }

    public void Display()
    {
        Console.WriteLine($"Number 1 >> {Num1}");
        Console.WriteLine($"Number 2 >> {Num2}");
    }

    public void Update(int num1, int num2)
    {
        Num1 = num1;
        Num2 = num2;
    }

    public int Sum()
    {
        return Num1 + Num2;
    }

    public int Max()
    {
        return Math.Max(Num1, Num2);
    }
}

class Program
{
    static void Main()
    {
        Numbers numbers = new Numbers();
        
        numbers.Update(10,20);
        
        numbers.Display();

        Console.WriteLine($"Сумма номеров >> {numbers.Sum()}");

        Console.WriteLine($"Максимальный номер >> {numbers.Max()}");
    }
}