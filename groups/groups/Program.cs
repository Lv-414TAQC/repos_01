using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groups
{
    class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone {Name="Lumia 430", Company="Microsoft"},
                new Phone {Name="Mi 5", Company="Xiaomi"},
                new Phone {Name="LG G 3", Company="LG"},
                new Phone {Name="iPhone 5", Company="Apple"},
                new Phone {Name="Lumia 930", Company="Microsoft"},
                new Phone {Name="iPhone 6", Company="Apple"},
                new Phone {Name="Lumia 630", Company="Microsoft"},
                new Phone {Name="LG G4", Company="LG"}
            };
            var phoneGroups = phones.GroupBy(p => p.Company);
            /*foreach (IGrouping<string, Phone> g in phoneGroups)
            {
                Console.WriteLine(g.Key);
                foreach (var i in g)
                {
                    Console.WriteLine(i.Name);
                }
                Console.WriteLine();
                
            }*/

            var phoneGroups2 = phones.GroupBy(p => p.Company).Select(g => new { Name = g.Key, Count = g.Count() });
            foreach (var group in phoneGroups2)
            {
                Console.WriteLine($"{group.Name} - {group.Count}");
            }
            Console.ReadKey();
        }
    }
}
