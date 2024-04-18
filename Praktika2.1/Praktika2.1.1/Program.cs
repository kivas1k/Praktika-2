using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку J >> ");
        string J = Console.ReadLine();

        Console.Write("Введите строку S >> ");
        string S = Console.ReadLine();

        int count = Jewelsinstones(J, S);
        
        Console.WriteLine($"Количество символов из S, являющихся драгоценностями: {count}");
    }

    static int Jewelsinstones (string J, string S)
    {
        int count = 0;
        
        for (int i = 0; i < S.Length; i++)
        {
            for (int j = 0; j < J.Length; j++)
            {
                if (S[i] == J[j])
                {
                    count++;
                    
                    break; 
                }
            }
        }
        return count;
    }
}