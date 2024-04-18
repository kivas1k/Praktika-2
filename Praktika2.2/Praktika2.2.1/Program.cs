using System;

class Student
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Group { get; set; }
    public double[] Grades { get; set; }

    public Student(string name, DateTime birthDate, string group, double[] grades)
    {
        Name = name;
        BirthDate = birthDate;
        Group = group;
        Grades = grades;
    }

    public void Info(string name, DateTime birthDate, string group)
    {
        Name = name;
        BirthDate = birthDate;
        Group = group;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Информация");
        
        Console.WriteLine($"Фамилия: {Name}");
        
        Console.WriteLine($"Дата рождения: {BirthDate}");
        
        Console.WriteLine($"Группа: {Group}");
        
        Console.WriteLine($"Успеваемость");

        for (int i = 0; i < Grades.Length; i++)
        {
            Console.WriteLine($"Предмет {i + 1}: {Grades[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        double[] grades1 = { 4.2, 4.9, 4.8, 4.2, 4.7 };

        Student student1 = new Student("Силаев", new DateTime(2006, 8, 26), "1", grades1);
        
        student1.DisplayInfo();

        double[] grades2 = { 3.3, 3.2, 4.0, 5.0, 4, 4 };

        Student student2 = new Student("Гольцев", new DateTime(2005, 12, 25), "2", grades2);
        
        student2.DisplayInfo();
    }
}