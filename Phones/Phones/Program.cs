using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phones
{
    interface IPhone
    {
        int Number { get; set; }
        string Model { get; set; }
        int Weight { get; set; }
        string Color { get; set; }
        double DiagonalSize { get; set; }

    }
    public class Xiaomi : IPhone
    {
        public int Number { get; set; }
        public string Model { get; set; }
       public int Weight { get; set; }
       public string Color { get; set; }
       public double DiagonalSize { get; set; }
        public Xiaomi(string model, int weight, string color, double sizeD, int nb)
        {
            Number = nb;
            Model = model;
            Weight = weight;
            Color =  color;
            DiagonalSize = sizeD;
        }
        public static int operator +(Xiaomi x1, Xiaomi x2)
        {
            return  x1.Number + x2.Number;
        }
        public static Xiaomi operator ++(Xiaomi x)
        {
           return new Xiaomi ( x.Model, x.Weight, x.Color, x.DiagonalSize, x.Number++ );
           
        }
        public static bool operator >(Xiaomi x1, Xiaomi x2)
        {
            return x1.DiagonalSize > x2.DiagonalSize;
               
        }
        public static bool operator <(Xiaomi x1, Xiaomi x2)
        {
            return x1.DiagonalSize < x2.DiagonalSize;
        }
        public static bool operator ==(Xiaomi x1, Xiaomi x2)
        {
            return x1.Weight == x2.Weight && x1.DiagonalSize == x2.DiagonalSize && x1.Color == x2.Color && x1.Model == x2.Model;
        }
        public static bool operator !=(Xiaomi x1, Xiaomi x2)
        {
            return x1.Weight != x2.Weight || x1.DiagonalSize != x2.DiagonalSize || x1.Color != x2.Color || x1.Model != x2.Model;
        }
    }
    public class Samsung : IPhone
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public double DiagonalSize { get; set; }
        public Samsung(string model, int weight, string color, double sizeD, int nb)
        {
            Number = nb;
            Model = model;
            Weight = weight;
            Color = color;
            DiagonalSize = sizeD;
        }

        public static int operator +(Samsung s1, Xiaomi x2)
        {
            return s1.Number + x2.Number;
        }
        public static int operator +(Xiaomi s1, Samsung x2)
        {
            return x2.Number + s1.Number;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Xiaomi x1 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Xiaomi x2 = new Xiaomi("Mi2lite", 20, "black", 12.5, 1);
            Xiaomi x3 = new Xiaomi("Mi2", 20, "black", 10.5, 1);
            Samsung s1 = new Samsung("A30", 20, "red", 12.5, 1);
            
            //Console.WriteLine(x1 + x2); // 2
            //Console.WriteLine(x1 == x3); //false
            //Console.WriteLine(x1 > x3); // true
            //Console.WriteLine(x1 != x3); //true
            //Console.WriteLine(x1 < x3); //false
            //Console.WriteLine(x1 + s1); //2
            //Console.WriteLine(s1 + x1); //2
            //Console.WriteLine(x1++.Number);
        }
    }
}
