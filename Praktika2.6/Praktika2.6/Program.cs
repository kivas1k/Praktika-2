using System;
using System.Collections.Generic;
using Npgsql;

namespace DailyPlanner
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connString = @"Host=10.30.0.137;Port=5432;Database=gr622_sivvya;Username=gr622_sivvya;Password=Fkbcf201424!";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                CreateTables(conn);

                int userId = -1;
                
                while (userId == -1)
                {
                    Console.WriteLine("1. Log in");
                    Console.WriteLine("2. Register");
                    Console.WriteLine("3. Exit");
                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            userId = Login(conn); 
                            break;
                        case "2":
                            Register(conn); // Регистрация нового челика
                            break;
                        case "3":
                            Environment.Exit(0); 
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                
                ManageTasks(userId, conn); // если все нормально, то переходим к выполнению заданий
            }
        }

        static void CreateTables(NpgsqlConnection conn)
        {
            string createUserTableSql = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserId SERIAL PRIMARY KEY,
                    Username VARCHAR(50) NOT NULL UNIQUE,
                    Password VARCHAR(50) NOT NULL
                )";

            string createTaskTableSql = @"
                CREATE TABLE IF NOT EXISTS Tasks (
                    TaskId SERIAL PRIMARY KEY,
                    UserId INT REFERENCES Users(UserId),
                    Name VARCHAR(100) NOT NULL,
                    Description TEXT,
                    DateDue TIMESTAMP NOT NULL,
                    IsCompleted BOOLEAN NOT NULL DEFAULT FALSE
                )";

            using (var cmd = new NpgsqlCommand(createUserTableSql, conn))
            {
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new NpgsqlCommand(createTaskTableSql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        static int Login(NpgsqlConnection conn)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            string sql = @"
                SELECT UserId
                FROM Users
                WHERE Username = @Username AND Password = @Password";

            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("Username", username);
                cmd.Parameters.AddWithValue("Password", password);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Console.WriteLine("Login successful!");
                    return (int)result; 
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                    return -1; // Возвращаем -1 если вход неудачный
                }
            }
        }

        static void Register(NpgsqlConnection conn)
        {
            Console.Write("Enter a new username: ");
            string username = Console.ReadLine();
            
            Console.Write("Enter a new password: ");
            string password = Console.ReadLine();

            string checkUserSql = @"
                SELECT COUNT(*)
                FROM Users
                WHERE Username = @Username";

            using (var cmd = new NpgsqlCommand(checkUserSql, conn))
            {
                cmd.Parameters.AddWithValue("Username", username);
                long count = (long)cmd.ExecuteScalar();
                if (count > 0)
                {
                    Console.WriteLine("Username already exists. Please choose a different one.");
                    return;
                }
            }

            string insertUserSql = @"
                INSERT INTO Users (Username, Password)
                VALUES (@Username, @Password)";

            using (var cmd = new NpgsqlCommand(insertUserSql, conn))
            {
                cmd.Parameters.AddWithValue("Username", username);
                cmd.Parameters.AddWithValue("Password", password);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Registration successful!");
                }
                else
                {
                    Console.WriteLine("Registration failed. Please try again.");
                }
            }
        }

        static void ManageTasks(int userId, NpgsqlConnection conn)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. Edit a task");
                Console.WriteLine("3. Delete a task");
                Console.WriteLine("4. View tasks for today");
                Console.WriteLine("5. View tasks for tomorrow");
                Console.WriteLine("6. View tasks for the week");
                Console.WriteLine("7. View all tasks");
                Console.WriteLine("8. View incomplete tasks");
                Console.WriteLine("9. View completed tasks");
                Console.WriteLine("10. Exit");
                Console.Write("Choose an option: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(userId, conn);
                        break;
                    
                    case "2":
                        EditTask(userId, conn);
                        break;
                    
                    case "3":
                        DeleteTask(userId, conn);
                        break;
                    
                    case "4":
                        ViewTasksForToday(userId, conn);
                        break;
                    
                    case "5":
                        ViewTasksForTomorrow(userId, conn);
                        break;
                    
                    case "6":
                        ViewTasksForWeek(userId, conn);
                        break;
                    
                    case "7":
                        ViewAllTasks(userId, conn);
                        break;
                    
                    case "8":
                        ViewIncompleteTasks(userId, conn);
                        break;

                    case "9":
                        ViewCompletedTasks(userId, conn);
                        break;
                    
                    case "10":
                        exit = true;
                        break;
                    
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddTask(int userId, NpgsqlConnection conn)
        {
            Console.Write("Enter task name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            
            Console.Write("Enter task due date (yyyy-MM-dd HH:mm:ss): ");
            string dueDateStr = Console.ReadLine();
            
            DateTime dateDue = DateTime.Parse(dueDateStr);

            string insertTaskSql = @"
                INSERT INTO Tasks (UserId, Name, Description, DateDue, IsCompleted)
                VALUES (@UserId, @Name, @Description, @DateDue, @IsCompleted)";

            using (var cmd = new NpgsqlCommand(insertTaskSql, conn))
            {
                cmd.Parameters.AddWithValue("UserId", userId);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Description", description);
                cmd.Parameters.AddWithValue("DateDue", dateDue);
                cmd.Parameters.AddWithValue("IsCompleted", false);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Task added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add task.");
                }
            }
        }

        static void EditTask(int userId, NpgsqlConnection conn)
        {
            Console.Write("Enter the ID of the task you want to edit: ");
            int taskId = int.Parse(Console.ReadLine());

            Console.Write("Enter new task name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter new task description: ");
            string description = Console.ReadLine();
            
            Console.Write("Enter new due date (yyyy-MM-dd HH:mm:ss): ");
            string dueDateStr = Console.ReadLine();
            
            DateTime dateDue = DateTime.Parse(dueDateStr);

            string updateTaskSql = @"
        UPDATE Tasks
        SET Name = @Name, Description = @Description, DateDue = @DateDue
        WHERE TaskId = @TaskId AND UserId = @UserId";

            using (var cmd = new NpgsqlCommand(updateTaskSql, conn))
            {
                cmd.Parameters.AddWithValue("TaskId", taskId);
                cmd.Parameters.AddWithValue("UserId", userId);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Description", description);
                cmd.Parameters.AddWithValue("DateDue", dateDue);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Task updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update task.");
                }
            }
        }

        static void DeleteTask(int userId, NpgsqlConnection conn)
        {
            Console.Write("Enter the ID of the task you want to delete: ");
            int taskId = int.Parse(Console.ReadLine());

            string deleteTaskSql = @"
        DELETE FROM Tasks
        WHERE TaskId = @TaskId AND UserId = @UserId";

            using (var cmd = new NpgsqlCommand(deleteTaskSql, conn))
            {
                cmd.Parameters.AddWithValue("TaskId", taskId);
                cmd.Parameters.AddWithValue("UserId", userId);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Task deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete task.");
                }
            }
        }

        static void ViewTasksForToday(int userId, NpgsqlConnection conn)
        {
            DateTime today = DateTime.Today;
            ViewTasks(userId, conn, today, today.AddDays(1));
        }

        static void ViewTasksForTomorrow(int userId, NpgsqlConnection conn)
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);
            ViewTasks(userId, conn, tomorrow, tomorrow.AddDays(1));
        }

        static void ViewTasksForWeek(int userId, NpgsqlConnection conn)
        {
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);
            ViewTasks(userId, conn, startOfWeek, endOfWeek);
        }

        static void ViewAllTasks(int userId, NpgsqlConnection conn)
        {
            ViewTasks(userId, conn, null, null);
        }

        static void ViewIncompleteTasks(int userId, NpgsqlConnection conn)
        {
            ViewTasks(userId, conn, null, null, false);
        }

        static void ViewCompletedTasks(int userId, NpgsqlConnection conn)
        {
            ViewTasks(userId, conn, null, null, true);
        }

        static void ViewTasks(int userId, NpgsqlConnection conn, DateTime? startDate, DateTime? endDate,
            bool? isCompleted = null)
        {
            string sql = @"
        SELECT TaskId, Name, Description, DateDue, IsCompleted
        FROM Tasks
        WHERE UserId = @UserId";

            if (startDate.HasValue)
            {
                sql += " AND DateDue >= @StartDate";
            }

            if (endDate.HasValue)
            {
                sql += " AND DateDue < @EndDate";
            }

            if (isCompleted.HasValue)
            {
                sql += " AND IsCompleted = @IsCompleted";
            }

            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("UserId", userId);
                if (startDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("StartDate", startDate.Value);
                }

                if (endDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("EndDate", endDate.Value);
                }

                if (isCompleted.HasValue)
                {
                    cmd.Parameters.AddWithValue("IsCompleted", isCompleted.Value);
                }

                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Tasks:");
                    
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"Task ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, Description: {reader.GetString(2)}, Due Date: {reader.GetDateTime(3)}, Completed: {reader.GetBoolean(4)}");
                    }
                }
            }
        }
    }
}