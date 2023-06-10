using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsCatalog
{
    /// <summary>
    /// Represents a student.
    /// </summary>
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public List<Grade> Grades { get; set; }

        public Student(int id, string firstName, string lastName, int age, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            Grades = new List<Grade>();
        }
        /// <summary>
        /// Displays the details of the student.
        /// </summary>
        public void DisplayStudent()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine("Address:");
            Console.WriteLine($"City: {Address.City}");
            Console.WriteLine($"Street: {Address.Street}");
            Console.WriteLine($"Number: {Address.Number}");
            Console.WriteLine("Grades:");
            foreach (Grade grade in Grades)
            {
                Console.WriteLine($"Subject: {grade.Subject}");
                Console.WriteLine($"Value: {grade.Value}");
                Console.WriteLine($"Date and Time: {grade.DateTime}");
            }
        }
        /// <summary>
        /// Adds a grade to the student.
        /// </summary>
        /// <param name="grade">The grade to add.</param>
        public void AddGrade(Grade grade)
        {
            Grades.Add(grade);
        }
        /// <summary>
        /// Calculates the average grade for the student.
        /// </summary>
        /// <returns>The average grade.</returns>
        public double GetAverageGrade()
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            double sum = 0;
            foreach (Grade grade in Grades)
            {
                sum += grade.Value;
            }

            return sum / Grades.Count;
        }
        /// <summary>
        /// Calculates the subject-wise average grades for the student.
        /// </summary>
        /// <returns>A dictionary containing subject-wise average grades.</returns>
        public Dictionary<string, double> GetSubjectWiseAverages()
        {
            Dictionary<string, List<double>> subjectGrades = new Dictionary<string, List<double>>();
            foreach (Grade grade in Grades)
            {
                if (subjectGrades.ContainsKey(grade.Subject))
                {
                    subjectGrades[grade.Subject].Add(grade.Value);
                }
                else
                {
                    subjectGrades[grade.Subject] = new List<double> { grade.Value };
                }
            }

            Dictionary<string, double> subjectAverages = new Dictionary<string, double>();
            foreach (var subjectGrade in subjectGrades)
            {
                double average = subjectGrade.Value.Sum() / subjectGrade.Value.Count;
                subjectAverages[subjectGrade.Key] = average;
            }

            return subjectAverages;
        }
    }
}
