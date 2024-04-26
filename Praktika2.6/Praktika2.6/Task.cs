using System;

namespace DailyPlanner
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        
        public Task()
        {
            
        }
        
        public Task(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
            IsCompleted = false; 
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Task ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Completed: {(IsCompleted ? "Yes" : "No")}");
        }
    }
}