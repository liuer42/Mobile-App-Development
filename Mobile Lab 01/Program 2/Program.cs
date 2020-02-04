using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Program_2
{
    class Program
    {
        private static List<Person> people = new List<Person>();
        private static string name;
        private static int age;
        private static string id;
        private static int creditsEarned;
        private static int yearsServed;
        static void Main(string[] args)
        {
            while (true)
            {
                int input;

                Console.WriteLine("Please enter a \n" +
                                  "1) Student \n" +
                                  "2) Teacher \n" +
                                  "3) Print Results \n" +
                                  "4) End Program");

                while(!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("That was invalid. Enter a valid option.");
                }

                switch (input)
                {
                    case 1:
                        CreateStudent();
                        break;
                    case 2:
                        CreateTeacher();
                        break;
                    case 3:
                        PrintResults();
                        break;
                    case 4:
                        return;
                }
            }
        }

        private static void CreateStudent()
        {
            int counter = 1;

            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid. Enter age: ");
            }
            do
            {
                Console.WriteLine("Please enter a valid id (6 digits):");
                id = Console.ReadLine();
            }
            while (!Regex.IsMatch(id.ToString(), @"^\d{6}$"));
            foreach (var prog in typeof(ProgramName).GetEnumNames())
            {
                Console.Write($"{counter}) ");
                Console.WriteLine(prog);
                counter++;
            }

            int progChoice;
            while (!int.TryParse(Console.ReadLine(), out progChoice))
            {
                Console.WriteLine("Value was invalid. Enter a valid option: ");
            }
            Enum.TryParse<ProgramName>((progChoice-1).ToString(), out var progName);

            Console.WriteLine("Number of credits earned: ");
            while (!int.TryParse(Console.ReadLine(), out creditsEarned))
            {
                Console.WriteLine("Invalid value, try again: ");
            }

            people.Add(new Student
            {
                Name = name,
                Age = age,
                Id = Convert.ToInt32(id),
                ProgramName = progName,
                CreditsEarned = creditsEarned
            });

        }

        private static void CreateTeacher()
        {
            int counter = 1;

            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid. Enter age: ");
            }
            Console.WriteLine("Enter id:");
            do
            {
                Console.WriteLine("Please enter a valid id (6 digits):");
                id = Console.ReadLine();
            }
            while (!Regex.IsMatch(id.ToString(), @"^\d{6}$"));
            foreach (var prog in typeof(ProgramName).GetEnumNames())
            {
                Console.Write($"{counter}) ");
                Console.WriteLine(prog);
                counter++;
            }

            int progChoice;
            while (!int.TryParse(Console.ReadLine(), out progChoice))
            {
                Console.WriteLine("Value was invalid. Enter a valid option: ");
            }
            Enum.TryParse<ProgramName>((progChoice-1).ToString(), out var progName);


            Console.WriteLine("Enter years served: ");
            while (!int.TryParse(Console.ReadLine(), out yearsServed))
            {
                Console.WriteLine("Invalid. Enter a number: ");
            }

            people.Add(new Teacher()
            {
                Name = name,
                Age = age,
                Id = Convert.ToInt32(id),
                ProgramName = progName,
                YearsOfService = yearsServed
            });
        }

        private static void PrintResults()
        {
            foreach (var person in people)
            {
                if (person.GetType() == typeof(Student))
                {
                    var student = (Student)person;
                    Console.WriteLine($"ID:\t{student.Id} \n" +
                                      $"Name: {student.Name} \n" +
                                      $"Age: {student.Age} \n" +
                                      $"Program: {student.ProgramName} - {student.CreditsEarned} Credits Earned");
                }
                else if (person.GetType() == typeof(Teacher))
                {
                    var teacher = (Teacher) person;
                    Console.WriteLine($"ID:\t{teacher.Id} \n" +
                                      $"Name:   {teacher.Name} \n" +
                                      $"Age:  {teacher.Age} \n" +
                                      $"Program: {teacher.ProgramName} - {teacher.YearsOfService} Years of Service");
                }
                Console.WriteLine("------------------------");
            }
        }

        public class Person
        {
            public String Name { get; set; }
            public int Age { get; set; }
            public int Id { get; set; }
            public ProgramName ProgramName { get; set; }
        }

        public class Student : Person
        {
            public int CreditsEarned { get; set; }
        }

        public class Teacher : Person
        {
            public int YearsOfService { get; set; }
        }

        public enum ProgramName
        {
            Accounting,
            ComputerScience,
            GraphicDesign,
            Mathematics,
            Art
        }

    }
}
