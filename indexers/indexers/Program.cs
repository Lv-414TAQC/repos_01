using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexers
{
    class Program
    {
        class Employee
        {
            public string Name { get; set; }
        }
        class Department
        {
            private Employee[] the_array;
            public Department()
            {
                the_array = new Employee[3];
            }
            public Employee this[int index]
            {
                get { return the_array[index]; }
                set { the_array[index] = value; }
            }
            public Employee this[string name]
            {
                get
                {
                    
                    foreach (Employee emp in the_array)
                    {
                        if (name == emp.Name)
                            return emp;
                    }
                    return null;
                }
            }

        }
        static void Main(string[] args)
        {
            Department dept = new Department();
            dept[0] = new Employee { Name = "Jack" };
            dept[1] = new Employee { Name = "Bob" };
            Employee jack = dept[0];
            Employee bob = dept["Bob"];
            Console.WriteLine(jack.Name);
            Console.WriteLine(bob.Name);

            Console.ReadKey();
        }
    }
}
