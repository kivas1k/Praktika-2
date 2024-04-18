using System;

class Class
{
    public int Number1 { get; set; }
    public string Text { get; set; }

    public Class(int num, string str)
    {
        Number1 = num;
        Text = str;
    }

    public Class()
    {
        Number1 = 0;
        Text = "Текст";
    }

    ~Class()
    {
        Console.WriteLine("Удаление");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Номер >> {Number1}");
        Console.WriteLine($"Текст >> {Text}");
    }
}

class Program
{
    static void Main()
    {
        Class obj1 = new Class(10, "Hello");
        
        obj1.DisplayInfo();

        Class obj2 = new Class();
        
        obj2.DisplayInfo();
    }
}