using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    abstract class Shape 
    {
        public string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Shape(string name)
        {
            Name = name;
            //Console.WriteLine($"It`s {name}");
        }
        public abstract double Area();
        public abstract double Perimeter();
    }
    class Circle: Shape, IComparable
    {
        double radius;
        const double PI = 3.14;
        
        public  Circle(string name, double radius) : base(name)
        {
            this.radius = radius;
        }
        public override double Area()
        {
            return PI * radius * radius;
        }
        public override double Perimeter()
        {
            return 2*PI*radius;
        }
        public int CompareTo(object o)
        {
            Circle c = o as Circle;
            if (c != null)
                return this.Area().CompareTo(c.Area());
            else
                throw new Exception("Невозможно сравнить два объекта");
           
        }

    }
    class Square : Shape, IComparable
    {
        double side;
        public Square(string name, double side) : base(name)
        {
            this.side = side;
            
        }
        public override double Area()
        {
            return side * side;
        }
        public override double Perimeter()
        {
            return side*4;
        }
        public int CompareTo(object o)
        {
            Square s = o as Square;
            if (s != null)
                return this.Area().CompareTo(s.Area());
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            Console.WriteLine("Select type of shape: circle or square");

            try
            {

                string shape = Console.ReadLine();
                if (shape != "circle" && shape != "square")
                    throw new FormatException("Invalid data");

                int i = 0;
                while (i != 3)
                {
                    if (shape == "circle")
                    {
                        Console.WriteLine($"Input radius {i} shape");
                        double rad = Convert.ToDouble(Console.ReadLine());
                        Circle circle = new Circle(shape, rad);
                        shapes.Add(circle);
                        Console.WriteLine($"Area of shape is  {circle.Area()}");
                        Console.WriteLine($"Perimeter of shape is {circle.Perimeter()}");
                    }
                    if (shape == "square")
                    {
                        Console.WriteLine($"Input side {i} shape");
                        double sd = Convert.ToDouble(Console.ReadLine());
                        Square square = new Square(shape, sd);
                        shapes.Add(square);
                        Console.WriteLine($"Area of shape is  {square.Area()}");
                        Console.WriteLine($"Perimeter of shape is {square.Perimeter()}");
                    }
                    i++;
                }
            


            Shape j = shapes.FirstOrDefault();
            double max= j.Perimeter();
            
                foreach (Shape sh in shapes)
            {

                //Console.WriteLine($"It`s name of shape is {sh.Name}");
                //Console.WriteLine($"Area of shape is  {sh.Area()}");
                //Console.WriteLine($"Perimeter of shape is {sh.Perimeter()}");
                
                if (sh.Perimeter()> max)
                {
                   max = sh.Perimeter();
                   //ref double xRef = ref max;
                }

            }

            Console.WriteLine($"The largest perimeter of {shape} is {max}");
            shapes.Sort();
        }
             catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
