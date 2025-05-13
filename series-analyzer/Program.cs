namespace series_analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // the series list
            List<int> series = new List<int>();
            //enter the args to series list
            series = SplitString(string.Join(" ", args));

            Console.WriteLine("Welcome to the Series Analyzer");
            Console.WriteLine($"\nYour Series is: ");
            PrintList(series);

            while (true)
            {
                //if "series" List is empty jump to "EnterList"
                if (series.Count() > 0)
                {
                    series = MenuManager(series);
                }
                else
                {
                    series = SplitString(EnterList());
                }
                continue;
            }
        }

        //run menu
        static List<int> MenuManager(List<int> series)
        {
            // print menu options
            Console.WriteLine("\n\nMenu: \n" +
                "a. Input a Series.\n" +
                "b. Display the series in the order it was entered.\n" +
                "c. Display the series in the reversed order it was entered.\n" +
                "d. Display the series in sorted order.\n" +
                "e. Display the Max value of the series.\n" +
                "f. Display the Min value of the series.\n" +
                "g. Display the Average of the series.\n" +
                "h. Display the Number of elements in the series.\n" +
                "i. Display the Sum of the series.\n" +
                "j. Exit.\n" +
                "Enter your Choice");
            // user input menu option
            string UserMenuChoice = Console.ReadLine();
            series = MenuSwitcher(UserMenuChoice.ToLower(), series);
            return series;
        }

        static List<int> MenuSwitcher(string MenuChoice, List<int> series)
        {
            // switch case for menu inputted option 
            // validate with "default" case option 
            Console.WriteLine("\n");
            switch (MenuChoice)
            {
                case "a":
                    {
                        Console.WriteLine("Input a Series.");
                        series = SplitString(EnterList());
                        break;
                    }
                case "b":
                    {
                        Console.Write("The order it was entered: ");
                        PrintList(series);
                        break;
                    }
                case "c":
                    {
                        Console.Write("In Reversed order: ");
                        PrintList(ReverseList(series));
                        break;
                    }
                case "d":
                    {
                        Console.Write("In Sorted order: ");
                        PrintList(SortList(series));
                        break;
                    }
                case "e":
                    {
                        Console.Write("The Max value of the series: ");
                        Console.WriteLine(FindMax(series));
                        break;
                    }
                case "f":
                    {
                        Console.Write("The Min value of the series: ");
                        Console.WriteLine(FindMin(series));
                        break;
                    }
                case "g":
                    {
                        Console.Write("The Average of the series: ");
                        Console.WriteLine(FindAverage(series));
                        break;
                    }
                case "h":
                    {
                        Console.Write("The Number of elements in the series: ");
                        Console.WriteLine(ListLen(series));
                        break;
                    }
                case "i":
                    {
                        Console.Write("The Sum of the series: ");
                        Console.WriteLine(ListSum(series));
                        break;
                    }
                case "j":
                    {
                        Console.WriteLine("Exiting Program...");
                        System.Environment.Exit(1);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice, try again");
                        return series;
                    }
            }
            return series;
        }

        //  a. enter list
        //enter string send to "split string"
        static string EnterList()
        {
            Console.WriteLine("Enter Series (put a space between the numbers): ");
            string input = Console.ReadLine();
            return input;
        }

        // b. PrintList
        static void PrintList(List<int> seriesList)
        {
            foreach (int i in seriesList)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }

        //c. reverse list
        static List<int> ReverseList(List<int> seriesList)
        {
            List<int> reversed = new List<int>();
            int len = ListLen(seriesList);
            for (int i = (len - 1); i >= 0; i--)
            {
                reversed.Add(seriesList[i]);
            }
            return reversed;
        }


        // d. sort list
        static List<int> SortList(List<int> seriesList)
        {
            List<int> UnSorted = new List<int>(seriesList);
            List<int> sorted = new List<int>();
            while(ListLen(UnSorted) > 0)
            {
                int min = FindMin(UnSorted);
                sorted.Add(min);
                UnSorted.Remove(min);
            }
            return sorted;
        }


        // e. max func
        // returns <int> max item in list
        static int FindMax(List<int> seriesList)
        {
            int max = seriesList[0];
            foreach (int i in seriesList)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        // f. min func
        // returns <int> min item in list
        static int FindMin(List<int> seriesList)
        {
            int min = seriesList[0];
            foreach (int i in seriesList)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }

        // g. average func
        // return<int> average of value of items in list
        static float FindAverage(List<int> seriesList)
        {
            int sum = ListSum(seriesList);
            int len = ListLen(seriesList);
            return (float)sum / len;
        }

        //  h. list len
        // returns <int> amount of item in list
        static int ListLen(List<int> seriesList)
        {
            int count = 0;
            foreach (int i in seriesList)
            {
                count ++;
            }
            return count;
        }


        // i. sum of list
        // return<int> sum of value of items in list
        static int ListSum(List<int> seriesList)
        {
            int total = 0;
            foreach (int i in seriesList)
            {
                total += i;
            }
            return total;
        }

        // split string
        // validate items (str,positive,at lest 3 items) and then add to "series" List 
        // if not invalid jump to "enter list"
        static List<int> SplitString(string series_input)
        {
            if (series_input.Length == 0)
            {
                Console.WriteLine("series cannot be empty");
                return new List<int>();
            }
            string[] splited = series_input.Split();

            if (splited.Length < 3)
            {
                Console.WriteLine("Series cannot be less then 3 items");
                return new List<int>();
            }
            List<int> ints = new List<int>();
            foreach (string num in splited)
            {
                if (int.TryParse(num, out int converted_number))
                {
                    if (converted_number > 0)
                    {
                        ints.Add(converted_number);
                    }
                    else
                    {
                        Console.WriteLine("Series cannot contain Negative Numbers");
                        return new List<int>();
                    }
                }
                else
                {
                    Console.WriteLine("Series can only contain Numbers");
                    return new List<int>();
                }
            }
            return ints;
        }
    }
}