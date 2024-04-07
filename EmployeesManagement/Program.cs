/*3. OldestAgeForEachCompany - finds the oldest aged employee for each unique company and returns the results as a Dictionary<string, Employee> sorted by key, where Key[string] is the unique company name, and Value[Employee] is the oldest employee in this company.
2
Here is the description of the Employee class:
* FirstName [string] - the first name of the emplovee.
LastName[string] - the last name of the employee.
* Company [string] - the company of the emplovee.
* Age [int] - the age of the employee.*/


// Importing namespaces that contain classes and methods used in this code file.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Defining the namespace for the current solution.
namespace Solution
{
    public class Solution
    {
        // Defining a method to calculate the average age for each company.
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            // Creating a new dictionary to store the results.
            var result = new Dictionary<string, int>();

            // Iterating over each unique company name in the list of employees.
            foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
            {
                // Calculating the average age of employees for the current company and rounding it to the nearest whole number.
                result.Add(company, (int)Math.Round(employees.Where(x => x.Company == company).Average(y => y.Age), 0));
            }

            // Returning the dictionary containing the average age for each company.
            return result;
        }

        // Defining a method to count the number of employees for each company.
        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            // Creating a new dictionary to store the results.
            var result = new Dictionary<string, int>();

            // Iterating over each unique company name in the list of employees.
            foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
            {
                // Counting the number of employees for the current company.
                result.Add(company, employees.Count(x => x.Company == company));
            }

            // Returning the dictionary containing the count of employees for each company.
            return result;
        }

        // Defining a method to find the oldest employee for each company.
        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            // Creating a new dictionary to store the results.
            var result = new Dictionary<string, Employee>();

            // Iterating over each unique company name in the list of employees.
            foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
            {
                // Finding the oldest employee for the current company.
                result.Add(company, employees.Where(x => x.Company == company).OrderByDescending(y => y.Age).First());
            }

            // Returning the dictionary containing the oldest employee for each company.
            return result;
        }

        // Defining the main method, which serves as the entry point of the program.
        public static void Main()
        {
            // Reading the number of employees from the console input and parsing it to an integer.
            int countOfEmployees = int.Parse(Console.ReadLine());

            // Creating a new list to store the employee data.
            var employees = new List<Employee>();

            // Looping over the input data to read employee details and populate the list.
            for (int i = 0; i < countOfEmployees; i++)
            {
                // Reading a line of input from the console.
                string str = Console.ReadLine();
                
                // Splitting the input line into an array of strings based on space (' ') delimiter.
                string[] strArr = str.Split(' ');

                // Creating a new Employee object and adding it to the list.
                employees.Add(new Employee
                {
                    FirstName = strArr[0],   // Assigning the first name of the employee.
                    LastName = strArr[1],    // Assigning the last name of the employee.
                    Company = strArr[2],     // Assigning the company of the employee.
                    Age = int.Parse(strArr[3])  // Parsing and assigning the age of the employee.
                });
            }

            // Printing the average age for each company.
            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            // Printing the count of employees for each company.
            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            // Printing the oldest employee for each company.
            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    // Defining a class named Employee to represent employee data.
    public class Employee
    {
        public string FirstName { get; set; }  // Property to store the first name of the employee.
        public string LastName { get; set; }   // Property to store the last name of the employee.
        public int Age { get; set; }           // Property to store the age of the employee.
        public string Company { get; set; }    // Property to store the company of the employee.
    }
}
