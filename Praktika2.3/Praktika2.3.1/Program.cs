using System;

class Worker
{
    private string name;
    private string surname;
    private double rate;
    private int days;

    public Worker(string name, string surname, double rate, int days)
    {
        this.name = name;
        this.surname = surname;
        this.rate = rate;
        this.days = days;
    }

    public string GetName()
    {
        return name;
    }

    public string GetSurname()
    {
        return surname;
    }

    public double GetRate()
    {
        return rate;
    }

    public int GetDays()
    {
        return days;
    }

    public void GetSalary()
    {
        double salary = rate * days;
        Console.WriteLine($"Зарплата работника {name} {surname}: {salary}");
    }
}

class Program
{
    static void Main()
    {
        List<Worker> workers = new List<Worker>();
        
        workers.Add(new Worker("Владислав", "Силаев", 50, 15));
        workers.Add(new Worker("Барак", "Обэме", 30, 28));
        workers.Add(new Worker("Sage", "Revive me", 20, 28));
        
        foreach (var worker in workers)
        {
            worker.GetSalary();
            
            Console.WriteLine($"Имя: {worker.GetName()}");
            Console.WriteLine($"Фамилия: {worker.GetSurname()}");
            Console.WriteLine($"Ставка: {worker.GetRate()}");
            Console.WriteLine($"Отработанные дни: {worker.GetDays()}\n");
        }
    }
}