using System;
using System.Collections.Generic;

class Converter
{
    private Dictionary <char, int> Values = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    public int RomeEl(string s) // Метод, который преобразует римское число в десятичное
    {
        int result = 0;

        for (int i = 0; i < s.Length; i++) // Проходим по каждому символу в строке с римским числом
        {
            if (i < s.Length - 1 && Values[s[i]] < Values[s[i + 1]])
            {
                result -= Values[s[i]];
            }
            else
            {
                result += Values[s[i]];
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        Converter converter = new Converter(); // Тесты

        string input1 = "III";
        Console.WriteLine($"№1 Вход >> \"{input1}\", Выход >> {converter.RomeEl(input1)}");

        string input2 = "LVIII";
        Console.WriteLine($"№2: Вход >> \"{input2}\", Выход >> {converter.RomeEl(input2)}");

        string input3 = "MCMXCIV";
        Console.WriteLine($"№3: Вход >> \"{input3}\", Выход >> {converter.RomeEl(input3)}");
    }
}