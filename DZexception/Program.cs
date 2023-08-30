using DZexception;

internal class Program
{
    private static void Main(string[] args)
    {

       
        string[] menuItems = new string[] { "a", "b", "c" };
        int row = Console.CursorTop + 1;
        int col = Console.CursorLeft;
        int index = 0;
        


        while (true)
        {
            try
            {               

                DrawMenu(menuItems, row, col, index);
                var keyNow = Console.ReadKey();
                switch (keyNow.Key)
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
                        var resultParse = Processing(menuItems[0], menuItems[1], menuItems[2]);
                        if (resultParse.a == 0 && resultParse.b == 0 && resultParse.c == 0)
                        {
                            menuItems[0] = "a";
                            menuItems[1] = "b";
                            menuItems[2] = "c";
                            break;
                        }
                        var sol = Solution(resultParse.a, resultParse.b, resultParse.c);
                        Console.WriteLine($"\n{menuItems[0]} * x^2 + {menuItems[1]} * x + {menuItems[2]} = 0");
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
                        menuItems[0] = "a";
                        menuItems[1] = "b";
                        menuItems[2] = "c";
                        break;
                    default:
                        switch (index)
                        {
                            case 0:
                                menuItems[0] = menuItems[0].Trim('a') + keyNow.KeyChar;
                                break;
                            case 1:
                                menuItems[1] = menuItems[1].Trim('b') + keyNow.KeyChar;
                                break;
                            case 2:
                                menuItems[2] = menuItems[2].Trim('c') + keyNow.KeyChar;
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
                menuItems[0] = "a";
                menuItems[1] = "b";
                menuItems[2] = "c";
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
        Console.WriteLine($"{items[0]} * x^2 + {items[1]} * x + {items[2]} = 0");
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
    private static (int a, int b, int c) Processing(string a, string b, string c)
    {
        var i = 0;
        string perem = "a";
        string err = "";

        try
        {
            int aInt;
            int bInt;
            int cInt;
            aInt = Int32.Parse(a.Trim('a'));
            i++;
            bInt = Int32.Parse(b.Trim('b'));
            i++;
            cInt = Int32.Parse(c.Trim('c'));
            return (aInt, bInt, cInt);
        }
        catch (System.OverflowException)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            if (i == 0) { perem = "a"; } else if (i == 1) { perem = "b"; } else if (i == 2) { perem = "c"; }
            if (i == 0) { err = a; } else if (i == 1) { err = b; } else if (i == 2) { err= c; }
            Console.WriteLine($"{perem} = {err} диапазон значений int = От -2 147 483 648 до 2 147 483 647");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            return (0, 0, 0);
        }
        catch
        {
            if (i == 0) { perem = "a"; } else if (i == 1) { perem = "b"; } else if (i == 2) { perem = "c"; }

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Неверный формат параметра {perem}");
            Console.WriteLine($" a = {a} \n b = {b} \n c = {c}");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            return (0, 0, 0);
            //return StartInput();
        }
    }

    //Ввод
    private static (int a, int b, int c) StartInput()
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
    private static (int x1, int x2, int D) Solution(int a, int b, int c)
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

