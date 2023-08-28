internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            var input = StartInput();
            var a = input.a;
            var b = input.b;
            var c = input.c;

            var sol = Solution(a, b, c);
            if (sol.D > 0)
            {
                Console.WriteLine("x1= {0}\n x2= {1}", sol.x1, sol.x2);
            }
            else
            {
                Console.WriteLine("x= {0}", sol.x1);
            }

        }

    }


    //Обработка ввода
    public static (int a, int b, int c) Processing(string a, string b, string c)
    {
        var i = 0;
        string perem = "a";

        try
        {
            var aInt = Int32.Parse(a);
            i++;
            var bInt = Int32.Parse(b);
            i++;
            var cInt = Int32.Parse(c);
            i++;
            return (aInt, bInt, cInt);
        }

        catch
        {
            if (i == 0) { perem = "a"; } else if (i == 1) { perem = "b"; } else if (i == 2) { perem = "c"; }

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Неверный формат параметра {perem}");
            Console.WriteLine($" a = {a} \n b = {b} \n c = {c}");
            Console.ResetColor();
            return StartInput();
        }
    }

    //Ввод
    public static (int a, int b, int c) StartInput()
    {
        Console.WriteLine("a * x^2 + b * x + c = 0");
        Console.WriteLine("Введите значение a:");
        var a = Console.ReadLine();
        Console.WriteLine("Введите значение b:");
        var b = Console.ReadLine();
        Console.WriteLine("Введите значение c:");
        var c = Console.ReadLine();

        var processing = Processing(a, b, c);
        var aInt = processing.a;
        var bInt = processing.b;
        var cInt = processing.c;

        return (aInt, bInt, cInt);
    }

    //Решение
    public static (int x1, int x2, int D) Solution(int a, int b, int c)
    {
        int D;
        int x1;
        int x2;

        D = (int)(Math.Pow(b, 2) - 4 * a * c);

        if (D > 0 || D == 0)
        {
            x1 = (int)((-b + Math.Sqrt(D)) / (2 * a));
            x2 = (int)((-b - Math.Sqrt(D)) / (2 * a));
            return (x1, x2, D);
        }


        else
        {
            Console.WriteLine("Действительных корней нет");
            return (0, 0, 0);
        }
    }

}

