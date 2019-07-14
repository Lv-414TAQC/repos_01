using System;
using System.Collections.Generic;
using System.Linq;

namespace delegates_hw
{  
    public static class MathClass
    {
        public static List<int> Evens(params int[] args)
        {
            List<int> y = new List<int>();
            foreach (int n in args)
            {
                if (n % 2 == 0)
                    y.Add(n);
            }
            return y;
        }
        public static List<int> Odds(params int[] args)
        {
            List<int> y = new List<int>();
            foreach (int n in args)
            {
                if (n % 2 != 0)
                    y.Add(n);
            }
            return y;
        }

        public delegate List<int> Del_1(int[] x);

        public static int Sum_(Del_1 x, params int[] args)
        {
            if(x != null)
            {
                List<int> filtered = x(args);
                int result = 0;
                foreach (int i in filtered)
                    result += i;
                return result;
            }
            else
            {
                List<int> unfiltered = new List<int>();
                foreach (var i in args)
                    unfiltered.Add(i);
                int result = 0;
                foreach (int i in unfiltered)
                    result += i;
                return result;
            }
        }
        public static int Max_(Del_1 x, params int[] args)
        {
            if(x != null)
            {
                List<int> filtered = x(args);
                int result = 0;
                foreach (int i in filtered)
                {
                    if (i > result)
                        result = i;
                }
                return result;
            }
            else
            {
                List<int> unfiltered = new List<int>();
                foreach (var i in args)
                    unfiltered.Add(i);
                int result = 0;
                foreach (int i in unfiltered)
                {
                    if (i > result)
                        result = i;
                }
                return result;
            }
        }
        public static int Avg_(Del_1 x, params int[] args)
        {
            if(x != null)
            {
                List<int> filtered = x(args);
                int result = 0;
                foreach (int i in filtered)
                    result += i;
                return result / filtered.Count();
            }
            else
            {
                List<int> unfiltered = new List<int>();
                foreach (var i in args)
                    unfiltered.Add(i);
                int result = 0;
                foreach (int i in unfiltered)
                    result += i;
                return result / unfiltered.Count();
            }
            
        }

        public delegate int Del_2(Del_1 x, int[] args);
    }
    class Program
    {
        public static void Output(MathClass.Del_1 del_1, MathClass.Del_2 del_2, int[] arr)
        {
            int? result = del_2?.Invoke(del_1, arr);
            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {   
            Console.WriteLine("Enter an array of integers:");
            string ints_string = Console.ReadLine();

            string[] ints_string_array = ints_string.Split(new string[] { " ", ",", ", " },
                StringSplitOptions.RemoveEmptyEntries);
            var ints_array = new int[ints_string_array.Length];
            for(var i = 0; i < ints_string_array.Length; i++)
            {
                ints_array[i] = Convert.ToInt32(ints_string_array[i]);
            }

            Console.WriteLine("Enter 'evens' or 'odds':");
            string filter = Console.ReadLine().ToLower();

            Console.WriteLine("Enter 'sum', 'max' or 'avg':");
            string action = Console.ReadLine().ToLower();

            MathClass.Del_1 del_filter = null;

            if (filter == "evens")
            {
                del_filter = MathClass.Evens;
            }
            else if (filter == "odds")
            {
                del_filter = MathClass.Odds;
            }
            else
            {
                Console.WriteLine("You entered invalid filter. It should be either 'evens' or 'odds'." +
                    "Given array was not filtered.");
            }

            MathClass.Del_2 del_action = null;

            if (action == "sum")
            {
                del_action = MathClass.Sum_;
            }
            else if(action == "max")
            {
                del_action = MathClass.Max_;
            }
            else if(action == "avg")
            {
                del_action = MathClass.Avg_;
            }
            else
            {
                Console.WriteLine("You entered invalid action. It should be either 'sum', 'max' or 'avg'.");
            }

            Output(del_filter, del_action, ints_array);
            Console.ReadKey();
        }
    }
}
