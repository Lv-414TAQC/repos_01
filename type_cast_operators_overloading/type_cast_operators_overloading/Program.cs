using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace type_cast_operators_overloading
{
    class Program
    {
        struct Digit
        {
            byte x;
            public Digit(byte y)
            {
                if (y > 9 && y < 0)
                {
                    throw new ArgumentException();
                }
                x = y;
            }
            public static explicit operator Digit(byte n)
            {
                Digit d = new Digit(n);
                Console.WriteLine("Conversion occured.");
                return d;
            }
            public static implicit operator byte(Digit n)
            {
                Console.WriteLine("Conversion occured.");
                return n.x;
            }
        }
        static void Main(string[] args)
        {
            byte g = 5;
            Digit t = (Digit)g;
            Console.WriteLine(t.GetType());
            byte r = t;
            Console.WriteLine(r.ToString());
            Console.ReadKey();
        }
    }
}
