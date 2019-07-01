using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_with_collections_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input an array of integers. Determine the middle element and move all elements that are " +
                "smaller that the middle one to the left side of the collection and those greater to the right side.");
            Console.WriteLine("The array: ");
            string input = Console.ReadLine();
            string[] input_array = input.Split(new char[] { ' ', ',' });
            List<int> the_list = new List<int>();
            foreach (string i in input_array)
            {
                the_list.Add(Convert.ToInt32(i));
            }
            int the_middle;
            if (the_list.Count % 2 == 0)
                the_middle = (the_list.Count / 2) - 1;
            else
                the_middle = the_list.Count / 2;
            List<int> the_result = new List<int>();
            foreach(int i in the_list)
            {
                if(i < the_list[the_middle])
                    the_result.Add(i);
            }
            the_result.Add(the_list[the_middle]);
            foreach(int i in the_list)
            {
                if (i > the_list[the_middle])
                    the_result.Add(i);
            }
            Console.WriteLine("The result is: ");
            foreach(int i in the_result)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
