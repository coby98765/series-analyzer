using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace series_analyzer
{
    class Program()
    {
        List<int> series = new List<int>();
        // set "series" to the return of "split string".ToList() with the "args" as default
        void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Series Analyzer");

            //if "series" List is empty jump to "EnterList"
            series.AddRange(SplitString(args));
            if (series.Count() > 0)
                {
                MenuManager();
            }
            else
            {
                EnterList();
            }
        }

        //run menu
        string MenuManager() {
            // print menu options
            Console.WriteLine("Menu\n1) ");
            // user input menu option
            string user_input = Console.ReadLine();
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

            return user_input;
        }
        // show list
        void PrintList()
        {
            Console.WriteLine(series);
        }

        // enter list
        //enter string send to "split string"
        void EnterList()
        {
            Console.WriteLine("Enter Series (put a space between the numbers: ");
        }

        // sorted list
        //sort and return list

        // max func
        // return<int> max item in list

        // min func
        // return<int> min item in list

        // average func
        // return<int> average of value of items in list

        // sum of list
        // return<int> sum of value of items in list

        // split string
        // validate items (str,positive,at lest 3 items) and then add to "series" List 
        // if not invalid jump to "enter list"

        List<int> SplitString(string[] series_input)
        {
            List<int> ints = new List<int>();
            foreach (string num in series_input)
            {
                if (int.TryParse(num, out int converted_number))
                {
                    if (converted_number > 0)
                    { 
                    ints.Add(converted_number);
                    continue;
                }
                }
                    return new List<int>();
            }
            return ints;
        }
    }
}