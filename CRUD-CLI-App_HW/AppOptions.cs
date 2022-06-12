using CRUD_CLI_App_HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_CLI_App_HW
{
    public class AppOptions
    {
        public static void Entry()
        {

            Console.WriteLine("What would you like to do:\n 1. Create Student\n 2. Delete Student\n 3. Update Student\n 4. Get Student Details\n 5. Get List Of All Students\n 6.Quit the App\n");
            int select = int.Parse(Console.ReadLine());

            switch (select)
            {
                case 1:
                    CreateStudent();
                    break;
                case 2:
                    DeleteStudent();
                    break;
                case 3:
                    UpdateStudent();
                    break;
                case 4:
                    GetDetails();
                    break;
                case 5:
                    GetList();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please enter  valid number\n");
                    Entry();
                    break;
            }

        }

        public static void Next()
        {
            Console.WriteLine("\n1. Go back to menu\n2. Quit the App");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Entry();
                    break;
                case 2:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please enter  valid number\n");
                    Next();
                    break;
            }
        }

        public static void CreateStudent()
        {
            Console.Write("Enter student first name: ");
            string fName = Console.ReadLine();
            Console.Write("Enter student last name: ");
            string lName = Console.ReadLine();
            Console.Write("Enter student age: ");
            int age = int.Parse(Console.ReadLine());
            var student = new Student() { FirstName = fName, LastName = lName, Age = age };

            using (var context = new SchoolContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
                Console.WriteLine("Student added successfully!\n");
            }
            Next();
        }

        public static void DeleteStudent()
        {
            Console.Write("Enter student Id you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            try
            {
                using (var context = new SchoolContext())
                {
                    var student = context.Students.SingleOrDefault(x => x.StudentId == id);
                    context.Students.Remove(student);
                    context.SaveChanges();
                    Console.WriteLine("Student deleted successfully!\n");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter  valid Id\n");
                DeleteStudent();
            }

            Next();
        }

        public static void UpdateStudent()
        {
            Console.Write("Enter student Id you want to update: ");
            int id = int.Parse(Console.ReadLine());


            using (var context = new SchoolContext())
            {
                var student = context.Students.SingleOrDefault(x => x.StudentId == id);
                if (student != null)
                {
                    Console.WriteLine("What would you like to update:\n 1. First Name\n 2. Last Name\n 3. Age\n ");
                    int select = int.Parse(Console.ReadLine());

                    switch (select)
                    {
                        case 1:
                            Console.Write("Enter new first name: ");
                            student.FirstName = Console.ReadLine();

                            break;
                        case 2:
                            Console.Write("Enter new last name: ");
                            student.LastName = Console.ReadLine();

                            break;
                        case 3:
                            Console.Write("Enter new age: ");
                            student.Age = int.Parse(Console.ReadLine());

                            break;
                        default:
                            Console.WriteLine("Unvalid option\n");
                            UpdateStudent();

                            break;
                    }
                    context.SaveChanges();
                    Console.WriteLine("Student successfully updated!\n");
                    Next();

                }
                else
                {
                    Console.WriteLine("Please enter  valid Id\n");
                    UpdateStudent();
                }

            }



        }

        public static void GetDetails()
        {
            Console.Write("Enter student Id: ");
            int id = int.Parse(Console.ReadLine());

            using (var context = new SchoolContext())
            {
                var studentsFromDb = context.Students.SingleOrDefault(x => x.StudentId == id);
                if (studentsFromDb != null)
                {
                    Console.WriteLine($"First Name: {studentsFromDb.FirstName} | Last Name: {studentsFromDb.LastName} | Age: {studentsFromDb.Age}");
                    Next();
                }
                else
                {
                    Console.WriteLine("Please enter  valid Id\n");
                    GetDetails();
                }

            }

        }

        public static void GetList()
        {
            using (var context = new SchoolContext())
            {
                var studentsFromDb = context.Students.ToList();
                studentsFromDb.ForEach(x => Console.WriteLine($"First Name: {x.FirstName} | Last Name: {x.LastName} | Age: {x.Age}"));
            }
            Next();
        }
    }

}
