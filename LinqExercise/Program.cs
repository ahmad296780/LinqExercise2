using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {

            //TODO: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());

            //TODO: Print the Average of numbers
            Console.WriteLine(numbers.Average());

            //TODO: Order numbers in ascending order and print to the console
            numbers.OrderBy(number => number).ToList().ForEach(Console.WriteLine);

            //TODO: Order numbers in decsending order adn print to the console
            numbers.OrderByDescending(number => number).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-------------");
            //TODO: Print to the console only the numbers greater than 6
            numbers.Where(number => number > 6).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("---------");
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            numbers.OrderBy(numbers => numbers).Take(4).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("----------");

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(23, 4);
            numbers.OrderByDescending(numbers => numbers).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-----------------");
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            var filtered = employees.Where(employees => employees
                                    .FirstName
                                    .ToLower()
                                    .StartsWith('c') || employees
                                    .FirstName.ToLower()[0] == 's')
                                    .OrderBy(employees => employees.FirstName);

            // foreach (var item in filtered)
            foreach (var item in filtered)
            {
                Console.WriteLine(item.FullName);
            };
            Console.WriteLine("--------------");
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var _26 = employees.Where(employees => employees.Age > 26)
                               .OrderBy(employees => employees.Age)
                               .ThenBy(employees => employees.FirstName);
            foreach (var item in _26)
            {
                Console.WriteLine($"employees age {item.Age} ,"+
                                  $"employees full name {item.FullName}");
            }
            Console.WriteLine("-------------");
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var newemp = employees.Where(employees => employees
                                  .YearsOfExperience <= 10 && employees
                                  .Age > 35);
            Console.WriteLine(newemp.Sum(x=>x.YearsOfExperience));
            Console.WriteLine(newemp.Average(x=>x.YearsOfExperience));

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("zaka", "Rast", 30, 10)).ToList();


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
