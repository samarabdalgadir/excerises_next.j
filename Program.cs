using System;

class Program
{
    // ✅ Grade Calculator
    public static string CalculateGrade(int score, int attendance)
    {
        if (score < 0 || score > 100 || attendance < 0 || attendance > 100)
            return "Invalid Input";
        if (score >= 90 && attendance >= 80) return "A";
        if (score >= 80 && attendance >= 70) return "B";
        if (score >= 70 && attendance >= 60) return "C";
        if (score >= 60 && attendance >= 50) return "D";
        if (score >= 50 && attendance < 50) return "Incomplete";
        return "F";
    }

    public static void GradeMenu()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter score (0-100): ");
            int score = int.Parse(Console.ReadLine());
            Console.Write("Enter attendance (0-100): ");
            int attendance = int.Parse(Console.ReadLine());
            Console.WriteLine("Grade: " + CalculateGrade(score, attendance));
        }
    }

    // ✅ Prime + Factorial
    public static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0) return false;
        return true;
    }

    public static long CalculateFactorial(int number)
    {
        if (number > 20) return -1;
        long result = 1;
        for (int i = 2; i <= number; i++) result *= i;
        return result;
    }

    public static void PrimeFactorialMenu()
    {
        Console.Write("Check primes up to: ");
        int max = int.Parse(Console.ReadLine());
        for (int i = 2; i <= max; i++)
            Console.WriteLine($"{i} is prime? {IsPrime(i)}");

        Console.Write("Number for factorial: ");
        int num = int.Parse(Console.ReadLine());
        long fact = CalculateFactorial(num);
        Console.WriteLine(fact == -1 ? "Too large" : $"Factorial = {fact}");
    }

    // ✅ Array Operations
    public static double CalculateAverage(int[] numbers)
    {
        int sum = 0;
        foreach (int n in numbers) sum += n;
        return (double)sum / numbers.Length;
    }

    public static int FindMax(int[] numbers)
    {
        int max = numbers[0];
        foreach (int n in numbers) if (n > max) max = n;
        return max;
    }

    public static int FindMin(int[] numbers)
    {
        int min = numbers[0];
        foreach (int n in numbers) if (n < min) min = n;
        return min;
    }

    public static void SortArrayAscending(int[] numbers)
    {
        Array.Sort(numbers);
    }

    public static void ArrayMenu()
    {
        int[] arr = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine($"Average: {CalculateAverage(arr)}");
        Console.WriteLine($"Max: {FindMax(arr)}");
        Console.WriteLine($"Min: {FindMin(arr)}");

        SortArrayAscending(arr);
        Console.WriteLine("Sorted:");
        foreach (int num in arr) Console.Write(num + " ");
        Console.WriteLine();
    }

    // ✅ String Analysis
    public static void AnalyzeString(string text)
    {
        int upper = 0, lower = 0, digit = 0, space = 0, special = 0;
        foreach (char c in text)
        {
            if (char.IsUpper(c)) upper++;
            else if (char.IsLower(c)) lower++;
            else if (char.IsDigit(c)) digit++;
            else if (char.IsWhiteSpace(c)) space++;
            else special++;
        }

        Console.WriteLine($"Uppercase: {upper}, Lowercase: {lower}, Digits: {digit}, Spaces: {space}, Special: {special}");
    }

    public static bool IsPalindrome(string text)
    {
        text = text.ToLower().Replace(" ", "");
        for (int i = 0; i < text.Length / 2; i++)
            if (text[i] != text[text.Length - 1 - i]) return false;
        return true;
    }

    public static string ReverseWords(string sentence)
    {
        string[] words = sentence.Split(' ');
        Array.Reverse(words);
        return string.Join(" ", words);
    }

    public static void StringMenu()
    {
        Console.Write("Text to analyze: ");
        string input = Console.ReadLine();
        AnalyzeString(input);

        Console.Write("Palindrome check: ");
        string pal = Console.ReadLine();
        Console.WriteLine(IsPalindrome(pal) ? "Yes" : "No");

        Console.Write("Reverse sentence: ");
        string s = Console.ReadLine();
        Console.WriteLine("Reversed: " + ReverseWords(s));
    }

    // ✅ MAIN MENU
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n==== MENU ====");
            Console.WriteLine("1. Grade Calculator");
            Console.WriteLine("2. Prime & Factorial");
            Console.WriteLine("3. Array Analysis");
            Console.WriteLine("4. String Tools");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");
            string c = Console.ReadLine();
            Console.WriteLine();

            switch (c)
            {
                case "1": GradeMenu(); break;
                case "2": PrimeFactorialMenu(); break;
                case "3": ArrayMenu(); break;
                case "4": StringMenu(); break;
                case "0": return;
                default: Console.WriteLine("Invalid"); break;
            }
        }
    }
}
