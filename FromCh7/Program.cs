using System;
using System.Collections.Generic;


namespace FromCh7
{
    public class MusicTitle
    {
        string[] names = { "name1", "name2", "name3", "name4" };
        public IEnumerator<string> GetEnumerator()
        {
            for(int i = 0; i < 4; i++)
            {
                yield return names[i];
            }
        }

        public IEnumerable<string> Resverse()
        {
            for(int i = 3; i >= 0; i--)
            {
                yield return names[i];
            }
        }
        public IEnumerable<string> Subset(int index, int length)
        {
            for(int i=index-1;i<4 && i < (index + length); i++)
            {
                yield return names[i];
            }
        }
    }

   

    delegate double DoubleOp(double x);
    
    
    class Program
    {
        private delegate string GetAString();

        static void Main(string[] args)
        {
            Program pro = new Program();
            //pro.MusicTitlePractice();
            //pro.DelegatePractice();
            //pro.DelegatePractice2();
            //pro.DelegatePractice3();
            //pro.DelegatePractice4();
            //pro.DelegatePractice5();
            //pro.StringsPractice();
            //pro.StringPractice2();
            pro.StringPractice3();
        }
        public void MusicTitlePractice()
        {
            MusicTitle music = new MusicTitle();
            foreach(var i in music)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Reserve");
            foreach(var i in music.Resverse())
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Subset");
            foreach(var i in music.Subset(2, 4))
            {
                Console.WriteLine(i);
            }


        }

        public void DelegatePractice()
        {
            int x = 40;
            GetAString firstStringMethod = x.ToString;
            Console.WriteLine($"first string is {firstStringMethod()}");
            var balance = new Currency(30, 45);
            firstStringMethod = balance.ToString;
            Console.WriteLine($"second string is {firstStringMethod()}");
            firstStringMethod = new GetAString(Currency.GetCurrencyUnit);
            Console.WriteLine($"third string is {firstStringMethod()}");
        }

        public void ProcessAndDisplayNumber(DoubleOp operation, double number)
        {
            Console.WriteLine($"The result is: {operation(number)}");
        }

        public void DelegatePractice2()
        {
            DoubleOp[] operations =
            {
                MathOpeartoions.MultiplyByTwo,
                MathOpeartoions.Square
            };
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine($"Using operation[{i}]");
                ProcessAndDisplayNumber(operations[i], 2);
                ProcessAndDisplayNumber(operations[i], 3.12);
            }
        }

        public void ProcessAndDisplay2(Func<double,double> action, double number)
        {
            Console.WriteLine($"The result is: {action(number)}");
        }

        public void DelegatePractice3()
        {
            Func<double, double>[] operations =
            {
                MathOpeartoions.MultiplyByTwo,
                MathOpeartoions.Square
            };
        }

        public void DelegatePractice4()
        {
            Employee[] employees =
            {
                new Employee("name1", 1000),
                new Employee("name2",2000),
                new Employee("name3",1500),
                new Employee("name4",2500)
            };
            BubbleSorter.Sorter(employees, Employee.CompareSalary);
            foreach(var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public void DelegatePractice5()
        {
            string mid = ", second string, ";
            Func<string, string> andDel = delegate (string param)
            {
                param += mid;
                param += "thir string";
                return param;
            };
            Console.WriteLine(andDel("first string"));
        }

        //Strings and regular exoressions
        public void StringsPractice()
        {
            string greetingText = "Hello from LittleMao. ";
            greetingText += "Hello from Karena. ";
            greetingText += "Hello from Yilei. ";
            Console.WriteLine($"Not encoded: {greetingText}");
            for(int i = 'z'; i >= 'a'; i--)
            {
                char oldL = (char)i;
                char newL = (char)(i + 1);
                greetingText =  greetingText.Replace(oldL, newL);
            }
            for(int i='Z'; i>= 'A'; i--)
            {
                char oldL = (char)i;
                char newL = (char)i;
                greetingText= greetingText.Replace(oldL, newL);
            }
            Console.WriteLine($"Encoded: {greetingText}");
        }

        public void StringPractice2()
        {
            int x = 3, y = 4;
            FormattableString string1 = $"X is {x}, Y is {y}, the addition is {x + y}";
            for(int i=0; i<string1.ArgumentCount; i++)
            {
                Console.WriteLine($"the {i}th argument is {string1.GetArgument(i)}");
            }
            Console.WriteLine(string1);
        }

        public void StringPractice3()
        {
            var day = new DateTime(2018, 2, 16);
            Console.WriteLine($"{day:d}");
        }
    }
}
