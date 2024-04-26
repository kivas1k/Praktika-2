using System;

class Program
{
    static void Main(string[] args)
    {
        int[] candidates1 = { 2, 5, 2, 1, 2 };
        int target1 = 5;

        Console.WriteLine("Результат для первого набора данных >> ");
        var result1 = result(candidates1, target1);
        PrintResult(result1);

        int[] candidates2 = { 10, 1, 2, 7, 6, 1, 5 };
        int target2 = 8;

        Console.WriteLine("Результат для второго набора данных >>");
        var result2 = result(candidates2, target2);
        PrintResult(result2);
    }

    static void PrintResult(int[][] combinations)
    {
        foreach (var combination in combinations) // Проходим по всем комбинациям в результате
        {
            Console.Write("[");
            for (int i = 0; i < combination.Length; i++)  // Проходим по всем элементам в текущей комбинации
            {
                Console.Write(combination[i]);

                if (i < combination.Length - 1) // Если это не последний элемент, то добавляем разделитель
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }

    static int[][] result(int[] candidates, int target)
    {
        Array.Sort(candidates); // Сортируем входной массив кандидатов
        
        var result = new List<int[]>();
        
        Find(candidates, target, new int[candidates.Length], 0, 0, result);
        
        return result.ToArray();
    }

    static void Find(int[] candidates, int target, int[] current, int index, int pos, List<int[]> result)
    {
        if (target == 0)
        {
            int[] combination = new int[pos];  // Создаем новый массив с длиной == количеству использованных элементов
            
            Array.Copy(current, combination, pos);
            
            result.Add(combination);
            return;
        }

        for (int i = index; i < candidates.Length; i++) // Проходим по всем кандидатам, начиная с позиции index
        {
            if (candidates[i] > target)
            {
                break;
            }

            if (i > index && candidates[i] == candidates[i - 1])
            {
                continue;
            }
            
            current[pos] = candidates[i];
            
            Find(candidates, target - candidates[i], current, i + 1, pos + 1, result);
        }
    }
}