using System;
using System.Collections.Generic;
using System.Text;

namespace FromCh7
{
    public class Racer: IComparable<Racer>, IFormattable
    {
        public int ID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Country { get; }
        public int Wins { get; }

        public Racer(int id, string firstName, string lastName, string country)
            :this(id,firstName, lastName, country, wins : 0)
        { }
        public Racer(int id, string firstName, string lastName, string country, int wins)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Wins = wins;
        }

        public override string ToString() => $"{FirstName} {LastName}";

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null) format = "N";
            switch (format.ToUpper())
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "W":
                    return $"{ToString()}, Wins: {Wins}";
                case "C":
                    return $"{ToString()}, Country: {Country}";
                case "A":
                    return $"{ToString()}, Country: {Country}, Wins: {Wins}";
                default:
                    throw new FormatException(String.Format(formatProvider, "Format {format} is not allowed here!"));
            }
        }
        public string ToString(string format) => ToString(format, null);
        public int CompareTo(Racer other)
        {
            int compare = LastName?.CompareTo(other?.LastName) ?? -1;
            if(compare == 0)
        }
    }
    class Collections
    {
    }
}
