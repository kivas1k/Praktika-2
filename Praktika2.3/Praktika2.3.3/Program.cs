using System;

class Calculation
{
    private string calculationLine;

    public string CalculationLine
    {
        get { return calculationLine; }
        set { calculationLine = value; }
    }
    
    public void SetCalculationLine(string line)
    {
        calculationLine = line;
    }
    
    public void SetLastSymbolCalculationLine(char symbol)
    {
        calculationLine += symbol;
    }
    
    public string GetCalculationLine()
    {
        return calculationLine;
    }
    
    public char GetLastSymbol()
    {
        if (string.IsNullOrEmpty(calculationLine))
        {
            throw new InvalidOperationException("Строка вычисления пуста.");
        }
        
        return calculationLine[calculationLine.Length - 1];
    }
    
    public void DeleteLastSymbol()
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