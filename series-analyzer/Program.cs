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

            while (true)
            {
                //if "series" List is empty jump to "EnterList"
                if (series.Count() > 0)
                {
                    Console.WriteLine($"Your Series is: ");
                    PrintList(series);
                    series = MenuManager(series);
                }
                //else
                //{
                //    EnterList();
                //}
            }
        }

        //run menu
        static List<int> MenuManager(List<int> series)
        {
            // print menu options
            Console.WriteLine("Menu: \n" +
                "a.Input a Series.\n" +
                "b.Display the series in the order it was entered.\n" +
                "c.Display the series in the reversed order it was entered.\n" +
                "d.Display the series in sorted order.\n" +
                "e.Display the Max value of the series.\n" +
                "f.Display the Min value of the series.\n" +
                "g.Display the Average of the series.\n" +
                "h.Display the Number of elements in the series.\n" +
                "i.Display the Sum of the series.\n" +
                "j.Exit.\n" +
                "Enter your Choice");
            // user input menu option
            string UserMenuChoice = Console.ReadLine();
            series = MenuSwitcher(UserMenuChoice);
            return series;
        }

        static List<int> MenuSwitcher(string MenuChoice)
        {
            // switch case for menu inputted option 
            // validate with "default" case option 
            //switch (user_input)
            //{
            //    case "0":
            //        { Console.WriteLine("abc");
            //            break;
            //        }
            //    default:
            //        {
            //            Console.WriteLine("invalid choice, try again");
            //            return MenuManager();
            //        }
            //}
            return new List<int>();
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
                //sort and return list
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
        static List<int> SortList(List<int> unsorted)
        {
            List<int> sorted = new List<int>(unsorted);
            sorted.Sort();
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
            // Console.WriteLine($"The Maximum Number in the list: {max}");
            return max;
        }

        // f. min func
        // returns <int> min item in list
        static int FindMin(List<int> seriesList)
        {
            int min = seriesList[0];
            foreach (int i in seriesList)
            {
                if (i > min)
                {
                    min = i;
                }
            }
            //Console.WriteLine($"The Minimum Number in the list: {min}");
            return min;
        }

        // g. average func
        // return<int> average of value of items in list
        static float FindAverage(List<int> seriesList)
        {
            int sum = ListSum(seriesList);
            int len = ListLen(seriesList);
            return sum / len;
        }

        //  h. list len
        // returns <int> amount of item in list
        static int ListLen(List<int> seriesList)
        {
            int count = 0;
            foreach (int i in seriesList)
            {
                count += 1;
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
                    Console.WriteLine("Series cannot contain Strings");
                    return new List<int>();
                }
            }
            return ints;
        }
    }
}