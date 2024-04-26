using System;

class Program
{
    static void Main(string[] args)
    {
        int[] nums1 = { 1, 2, 3, 4 };
        Console.WriteLine(IfSame(nums1)); // -

        int[] nums2 = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
        Console.WriteLine(IfSame(nums2)); // +

        int[] nums3 = { 1, 2, 3, 1 };
        Console.WriteLine(IfSame(nums3)); // +
    }

    static bool IfSame(int[] nums)
    {
        int maxNum = 0;
        
        foreach (int num in nums)
        {
            if (num > maxNum)
            {
                maxNum = num;
            }
        }

        int[] count = new int[maxNum + 1];  // Массив для подсчета количества вхождений каждого числа

        foreach (int num in nums)
        {
            count[num]++;
            
            if (count[num] >= 2)  // Если для какого-то числа счетчик >= 2, значит что то попторяется
            {
                return true;
            }
        }
        return false; // если цифорка одинока(
    }
}