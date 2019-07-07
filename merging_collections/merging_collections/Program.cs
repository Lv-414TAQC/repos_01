using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merging_collections
{
    class Driver
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>()
            {
                new Team {Name="Mercedes", Country="Germany"},
                new Team {Name="Ferrari", Country="Italy"},
                new Team {Name = "AlfaRomeo", Country ="Italy"}
            };
            List<Driver> drivers = new List<Driver>()
            {
                new Driver {Name="Vettel", Team="Ferrari"},
                new Driver {Name="Hamilton", Team="Mercedes"},
                new Driver {Name="Bottas", Team="Mercedes"}
            };

            var result = drivers.Join(teams, dr => dr.Team, t => t.Name,
                (dr, t) => new { Name = dr.Name, Team = dr.Team, Country = t.Country });
                         
            //foreach (var item in result)
            //    Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");

            var result2 = teams.GroupJoin(drivers,
                t => t.Name,
                dr => dr.Team,
                (team, drs) => new { Name = team.Name, Country = team.Country, Drivers = drs.Select(dr => dr.Name) });
            /*foreach(var team in result2)
            {
                Console.WriteLine($"{team.Name} - {team.Country}");
                
                foreach (string driver in team.Drivers)
                {
                    Console.WriteLine("driver");
                }
                Console.WriteLine();
            }*/

            var result3 = drivers.Zip(teams,
                (driver, team) => new { Name = driver.Name, Team = team.Name, Country = team.Country });
            foreach (var dr in result3)
            {
                Console.WriteLine($"{dr.Name} - {dr.Team} ({dr.Country})");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        
    }
}
