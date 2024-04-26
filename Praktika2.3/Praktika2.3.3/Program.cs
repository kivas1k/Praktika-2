using System;

class Calculation
{
    private string calculationLine;

    public string CalculationLine  // Свойство для доступа к полю calculationLine
    {
        get { return calculationLine; }
        set { calculationLine = value; }
    }
    
    public void SetCalculationLine(string line) // Метод для установки строки вычисления
    {
        calculationLine = line;
    }
    
    public void SetLastSymbolCalculationLine(char symbol) // Метод для добавления символа в конец строки вычисления
    {
        calculationLine += symbol;
    }
    
    public string GetCalculationLine()  // Метод для получения строки вычисления
    {
        return calculationLine;
    }
    
    public char GetLastSymbol() // Метод для получения ласт символа строки вычисления
    {
        if (string.IsNullOrEmpty(calculationLine))
        {
            throw new InvalidOperationException("Строка вычисления пуста.");
        }
        
        return calculationLine[calculationLine.Length - 1];
    }
    
    public void DeleteLastSymbol() // Метод для удаления последнего символа из строки вычисления
    {
        if (!string.IsNullOrEmpty(calculationLine))
        {
            calculationLine = calculationLine.Remove(calculationLine.Length - 1); 
        }
    }
}

class Program
{
    static void Main()
    {
        Calculation calc = new Calculation();
        
        calc.SetCalculationLine("2 + 2 * 2 ");
        
        calc.SetLastSymbolCalculationLine('=');
        
        Console.WriteLine("Исходная строчка >> " + calc.GetCalculationLine());
        Console.WriteLine("Последний символ >> " + calc.GetLastSymbol());
        
        calc.DeleteLastSymbol();
        
        Console.WriteLine("Удалание последнего символа >> " + calc.GetCalculationLine());
    }
}