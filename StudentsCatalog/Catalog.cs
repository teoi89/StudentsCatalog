﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsCatalog
{
    /// <summary>
    /// Represents a catalog of students.
    /// </summary>
    class Catalog
    {
        private List<Student> students = new List<Student>();
        /// <summary>
        /// Generates a list of default students.
        /// </summary>
        public void GenerateDefaultStudents()
        {
            students = new List<Student>
            {
                new Student(1, "Dacian", "Marcu", 20, new Address("Oradea", "Noua", "1")),
                new Student(2, "Ioan", "Smith", 22, new Address("Alesd", "Lunga", "2")),
                new Student(3, "Michael", "Popescu", 21, new Address("Marghita", "Lalelelor", "3")),
                new Student(4, "Emily", "Papp", 19, new Address("Vascau", "Libertatii", "4")),
                new Student(5, "Daniel", "Marcovici", 23, new Address("Ciumeghiu", "Teiului", "5"))
            };

            Console.WriteLine("\nDefault students generated successfully.\n");
        }
        /// <summary>
        /// Displays all the students in the catalog.
        /// </summary>
        public void DisplayAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo students found.\n");
                return;
            }

            Console.WriteLine("\nAll Students:\n");
            foreach (Student student in students)
            {
                student.DisplayStudent();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Displays the details of a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        public void DisplayStudentById(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("\nStudent Details:\n");
                student.DisplayStudent();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"\nStudent with ID {id} not found.\n");
            }
        }
        /// <summary>
        /// Adds a new student to the catalog based on user input.
        /// </summary>
        public void AddStudentFromConsole()
        {
            Console.WriteLine("\nEnter student details:");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter address details:");
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.Write("Number: ");
            string number = Console.ReadLine();

            var address = new Address(city, street, number);

            Student student = new Student(id, firstName, lastName, age, address);
            students.Add(student);

            Console.WriteLine("\nStudent added successfully.\n");
            DisplayStudentAddress(student);
        }
        private void DisplayStudentAddress(Student student)
        {
            Console.WriteLine("\nStudent Address:");
            Console.WriteLine($"City: {student.Address.City}");
            Console.WriteLine($"Street: {student.Address.Street}");
            Console.WriteLine($"Number: {student.Address.Number}\n");
        }
        /// <summary>
        /// Removes a student from the catalog by their ID.
        /// </summary>
        /// <param name="id">The ID of the student to remove.</param>
        public void RemoveStudentById(int id)
        {
            int index = students.FindIndex(s => s.Id == id);
            if (index != -1)
            {
                students.RemoveAt(index);
                Console.WriteLine($"\nStudent with ID {id} has been removed.\n");
            }
            else
            {
                Console.WriteLine($"\nStudent with ID {id} not found.\n");
            }
        }
        /// <summary>
        /// Updates the data of a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student to update.</param>
        public void UpdateStudentData(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("\nEnter updated student details:");
                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;

                Console.WriteLine("\nStudent data updated successfully.\n");
            }
            else
            {
                Console.WriteLine($"\nStudent with ID {id} not found.\n");
            }
        }
        /// <summary>
        /// Updates the address of a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student to update.</param>
        public void UpdateStudentAddress(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("\nEnter updated address details:");
                Console.Write("City: ");
                string city = Console.ReadLine();
                Console.Write("Street: ");
                string street = Console.ReadLine();
                Console.Write("Number: ");
                string number = Console.ReadLine();

                Address address = new Address(city, street, number);
                student.Address = address;

                Console.WriteLine("\nStudent address updated successfully.\n");
            }
            else
            {
                Console.WriteLine($"\nStudent with ID {id} not found.\n");
            }
        }
        /// <summary>
        /// Assigns a grade to a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        public void AssignGradeToStudent(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("\nEnter grade details:");
                Console.Write("Subject: ");
                string subject = Console.ReadLine();
                Console.Write("Value: ");
                double value = double.Parse(Console.ReadLine());
                Console.Write("Teacher's Name: ");
                string teacherName = Console.ReadLine();

                Console.WriteLine("\nGrade assigned to the student.\n");
                Grade grade = new Grade(value, subject);
                student.AddGrade(grade);

                student.Teachers[subject] = teacherName; // Assign teacher's name for the subject

                
            }
            else
            {
                Console.WriteLine($"\nStudent with ID {id} not found.\n");
            }
        }
        /// <summary>
        /// Displays the overall average grade for a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        public void DisplayOverallAverage(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                double average = student.GetAverageGrade();
                Console.WriteLine($"\nOverall average for student with ID {id}: {average}\n");
            }
            else
            {
                Console.WriteLine($"\nStudent with ID {id} not found.\n");
            }
        }
        /// <summary>
        /// Displays the subject-wise average grades for a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        public void DisplaySubjectWiseAverage(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Dictionary<string, double> subjectAverages = student.GetSubjectWiseAverages();
                Console.WriteLine($"\nSubject-wise averages for student with ID {id}:");
                foreach (var subjectAverage in subjectAverages)
                {
                    Console.WriteLine($"{subjectAverage.Key}: {subjectAverage.Value}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"\nStudent with ID {id} not found.\n");
            }
        }
        /// <summary>
        /// Displays the students in the catalog in descending order of their average grades.
        /// </summary>
        public void DisplayStudentsInDescendingOrder()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo students found.\n");
                return;
            }

            List<Student> sortedStudents = students.OrderByDescending(s => s.GetAverageGrade()).ToList();
            Console.WriteLine("\nStudents in descending order of average:\n");
            foreach (Student student in sortedStudents)
            {
                student.DisplayStudent();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Updates the teacher's name.
        /// </summary>
        public void UpdateTeacherName(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Enter subject to update teacher's name: ");
                string subject = Console.ReadLine();

                if (student.Teachers.ContainsKey(subject))
                {
                    Console.Write("Enter updated teacher's name: ");
                    string teacherName = Console.ReadLine();

                    student.Teachers[subject] = teacherName;
                    Console.WriteLine("\nTeacher's name updated successfully.\n");
                }
                else
                {
                    Console.WriteLine($"\nStudent with ID {id} does not have a grade for the subject: {subject}.\n");
                }
            }
            else
            {
                Console.WriteLine($"\nStudent with ID {id} not found.\n");
            }
        }
    }
}