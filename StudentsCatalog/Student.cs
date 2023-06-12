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
        private IEnumerable<Grade> grades;

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
        /// Displays the student's information with teacher's names for each subject.
        /// </summary>
        public void DisplayStudentWithTeacher()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine("Grades:");
            foreach (Grade grade in grades)
            {
                Console.WriteLine($"Subject: {grade.Subject}, Teacher: {GetTeacherName(grade.Subject)}, Grade: {grade.Value}");
            }
            Console.WriteLine($"Average Grade: {GetAverageGrade()}");
            Console.WriteLine($"Address: {Address.City}, {Address.Street} {Address.Number}");
        }

        private object GetTeacherName(string subject)
        {
            throw new NotImplementedException();
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
