using System;
using System.Collections.Generic;
using System.Text;

namespace FromCh7
{

    public class NewRacer: IComparable<NewRacer> ,IFormattable
    {
        public NewRacer(string firstName, string lastName, string country, int starts, int wins)
            :this(firstName,lastName,country,starts, wins, null, null) { }
        public NewRacer(string firstName, string lastName, string country, int starts, int wins, IEnumerable<int> years,IEnumerable<string> cars)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Starts = starts;
            Wins = wins;
            Cars = cars != null ? new List<string>(cars) : new List<string>();
            Years = years != null ? new List<int>(years) : new List<int>();
        }
        
        public string FirstName { get; }
        public string LastName { get; }
        public string Country { get; }
        public int Starts { get; }
        public int Wins { get; }
        public IEnumerable<string> Cars { get; }
        public IEnumerable<int> Years { get; }

        public override string ToString() => $"{FirstName} {LastName}";

        public int CompareTo(NewRacer other) => LastName.CompareTo(other.LastName);

        public string ToString(string format) => ToString(format, null);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "C":
                    return Country;
                case "S":
                    return Starts.ToString();
                case "W":
                    return Wins.ToString();
                case "A":
                    return $"{FirstName} {LastName}, {Country}, starts: {Starts}, wins: {Wins}";
                default:
                    throw new FormatException($"Format {format} not supported");

            }
        }
    }
    
    public class Team
    {
        public Team(string name, params int[] years)
        {
            Name = name;
            Years = years != null ? new List<int>(years) : new List<int>();
        }
        public string Name { get; }
        public IEnumerable<int> Years { get; }
    }

    public class Formula1
    {
        private static List<NewRacer> s_racers;
        public static IList<NewRacer> GetChampions()
        {
            return s_racers ?? (s_racers = InitalizeRacers);
        }

        private static List<NewRacer> InitalizeRacers =>
            new List<NewRacer>
            {
                new NewRacer("Nino", "Farina", "Italy", 33, 5, new int[] {1950},new string[] { "Alfa Romeo"}),
                new NewRacer("Juan","Fangio","Argentina",32,10, new int[] {1952,1953 },new string[] {"Ferrari"}),
                new NewRacer("Alfa","Maserati","Mercedes",48,3,new int[] {2003,3234}, new string[] {"team1","team2","team3"}),
                new NewRacer("Phil","Hill","USA",45,3,new int[] {1961}, new string[] { "Ferrari"}),
                new NewRacer("Jim","Clark","UK",111,6,new int[] { 1963,1965},new string[] { "Lotus"})
            };
    }

    class Linq
    {
    }
}
