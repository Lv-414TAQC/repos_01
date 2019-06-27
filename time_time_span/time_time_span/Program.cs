using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace time_time_span
{
    class Program
    {
        class Time
        {
            public int Hours { get; set; }
            public int Minutes { get; set; }
            public double Seconds { get; set; }
            public Time(int h, int m, double s)
            {
                Hours = h;
                Minutes = m;
                Seconds = s;
            }

        }
        class TimeSpan
        {
            public int Seconds { get; set; }
            public int Miliseconds { get; set; }

            public TimeSpan(int s, int m)
            {
                Seconds = s;
                Miliseconds = m;
            }

            public static explicit operator TimeSpan(Time x)
            {
                //int first = x.Hours * 3600;
                //int second = x.Minutes * 60;
                int s = x.Hours * 3600 + x.Minutes * 60 + Convert.ToInt32(Math.Truncate(x.Seconds));
                int ms = Convert.ToInt32((x.Seconds - Math.Truncate(x.Seconds))*1000);
                //Console.WriteLine("To TimeSpan\ns = {0}, ms = {1}", s, ms);
                return new TimeSpan(s, ms); //{ Seconds = s, Miliseconds = ms };
            }
            public static implicit operator Time(TimeSpan x)
            {
                //int middle = Convert.ToInt32(Math.Truncate(x.Seconds));
                //Console.WriteLine(middle);
                double double_seconds = (double)x.Seconds + (double)x.Miliseconds / 1000;
                int h = Convert.ToInt32(Math.Truncate(double_seconds)) / 3600;
                //Console.WriteLine(h);
                int m = (Convert.ToInt32(Math.Truncate(double_seconds)) - h * 3600) / 60;
                //Console.WriteLine(m);
                double s = double_seconds - h * 3600 - m * 60;
                //Console.WriteLine(s);
                //Console.WriteLine("To Time\ndouble_seconds = {3}, h = {0}, m = {1}, s = {2}", h, m, s, double_seconds);
                return new Time(h, m, s); //{ Hours = h, Minutes = m, Seconds = Math.Round(s, 3) };
            }
        }
        static void Main(string[] args)
        {
            Time the_time = new Time(4, 36, 45.952); //{ Hours = 4, Minutes = 36, Seconds = 45.952 };
            //Console.WriteLine(the_time.Seconds);
            TimeSpan the_span = (TimeSpan)the_time;
            Console.WriteLine("The time span is {0},{1}", the_span.Seconds, the_span.Miliseconds);
            Time the_time_again = the_span;
            Console.WriteLine("The time is {0}:{1}:{2}", the_time_again.Hours, the_time_again.Minutes, the_time_again.Seconds);
            Console.ReadKey();
        }
    }
}
