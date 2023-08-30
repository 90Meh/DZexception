using DZexception;

internal class Program
{
    private static void Main(string[] args)
    {
        var a = "";
        var b = "";
        var c = "";
        string[] menuItems = new string[] { "a", "b", "c" };
        int row = Console.CursorTop;
        int col = Console.CursorLeft;
        int index = 0;
        
        

        while (true)
        {
            Console.WriteLine($"\n\n\n\n{a} * x^2 + {b} * x + {c} = 0");

            try
            {


                
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                DrawMenu(menuItems, row, col, index);


                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        var resultParse = Processing(a, b, c);
                        var sol = Solution(resultParse.a, resultParse.b, resultParse.c);
                        Console.WriteLine($"\n{a} * x^2 + {b} * x + {c} = 0");
                        if (sol.D > 0)
                        {
                            Console.WriteLine("x1= {0}\nx2= {1}", sol.x1, sol.x2);
                        }
                        else
                        {
                            Console.WriteLine("x= {0}", sol.x1);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        a = "";
                        b = "";
                        c = "";
                        break;
                    default:
                        switch (index)
                        {
                            case 0:
                                a = a + Console.ReadKey().KeyChar;
                                break;
                            case 1:
                                b = b + Console.ReadKey().KeyChar;
                                break;
                            case 2:
                                c = c + Console.ReadKey().KeyChar;
                                break;
                        }

                        break;
                }

                

            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.Message);
                Console.ReadLine();
                Console.Clear();
                a = "";
                b = "";
                c = "";
            }

        }

        //while (true)
        //{
        //    try
        //    {
        //        var input = StartInput();
        //        var a = input.a;
        //        var b = input.b;
        //        var c = input.c;

        //        var sol = Solution(a, b, c);
        //        if (sol.D > 0)
        //        {
        //            Console.WriteLine("x1= {0}\nx2= {1}", sol.x1, sol.x2);
        //        }
        //        else
        //        {
        //            Console.WriteLine("x= {0}", sol.x1);
        //        }

        //    }
        //    catch (Exception Ex)
        //    {
        //        Console.WriteLine(Ex.Message);
        //    }
        //}
    }
    private static void DrawMenu(string[] items, int row, int col, int index)
    {
        Console.SetCursorPosition(col, row);
        for (int i = 0; i < items.Length; i++)
        {

            if (i == index)
            {
                Console.WriteLine($">{items[i]}");
            }
            else
            {
                Console.WriteLine($" {items[i]}");
            }

        }
        Console.WriteLine();
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
            return (aInt, bInt, cInt);
        }

        catch
        {
            if (i == 0) { perem = "a"; } else if (i == 1) { perem = "b"; } else if (i == 2) { perem = "c"; }

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Неверный формат параметра {perem}");
            Console.WriteLine($" a = {a} \n b = {b} \n c = {c}");
            Console.ResetColor();
            return (0,0,0);
            //return StartInput();
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

        try
        {
            if (D > 0 || D == 0)
            {
                x1 = (int)((-b + Math.Sqrt(D)) / (2 * a));
                x2 = (int)((-b - Math.Sqrt(D)) / (2 * a));
                return (x1, x2, D);
            }
            else
            {
                throw new MyException().NoRootsException();
            }
        }
        catch
        {
            throw;
        }
    }


}

