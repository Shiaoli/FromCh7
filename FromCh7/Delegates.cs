using System;
using System.Collections.Generic;
using System.Text;

namespace FromCh7
{
    //pactice on delegate
    struct Currency
    {
        public uint Dollars;
        public ushort Cents;
        public Currency(uint dollars, ushort cents)
        {
            Dollars = dollars;
            Cents = cents;
        }
        public override string ToString() => $"{Dollars}.{Cents,2:00}";

        public static string GetCurrencyUnit() => "Dollar";
        public static explicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                ushort cents = (ushort)((value - dollars) * 100);
                return new Currency(dollars, cents);
            }
        }

        public static implicit operator float(Currency value)
            => value.Dollars + (float)(value.Cents / 100);

        public static implicit operator Currency(uint value) => new Currency(value, 0);

        public static implicit operator uint(Currency value) => value.Dollars;

    }
    public class MathOpeartoions
    {
        public static double MultiplyByTwo(double value) => value * 2;
        public static double Square(double value) => value * value;
    }
    class Delegates
    {
    }

    class BubbleSorter
    {
        static public void Sorter<T>(IList<T> sortArray,Func<T,T,bool> comparison)
        {
            bool swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Count - 1; i++)
                {
                    if (comparison(sortArray[i], sortArray[i + 1]))
                    {
                        T temp = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }

    class Employee
    {
        public string Name { get; }
        public decimal Salary { get; }
        public Employee(string name,decimal salary)
        {
            Name = name;
            Salary = salary;
        }
        public override string ToString() => $"{Name}, {Salary:C}";
        public static bool CompareSalary(Employee e1, Employee e2) =>
            e1.Salary < e2.Salary;
    }

    // Events
    public class CarInfoEventArgs: EventArgs
    {
        public CarInfoEventArgs(string car) => car = car;
        public string Car { get; }
    }

    public class CarDealar
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;
        public void NewCar(string car)
        {
            Console.WriteLine($"CarDealer, new Car {car}");
            NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
        }
    }

}
