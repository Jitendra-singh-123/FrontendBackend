using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExercise
{
    internal class Program
    {
        static EntityFrameWorkEntities db;
        static Student student;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertOperation();
                        break;
                    case "2":
                        UpdateOperation();
                        break;
                    case "3":
                        DeleteOperation();
                        break;
                    case "4":
                        SearchOperation();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public  static void SearchOperation()
        {
            try
            {
                db = new EntityFrameWorkEntities();
                Console.WriteLine("Enter Student id to search Student");
                int id = int.Parse(Console.ReadLine());
                Student student = db.Students.SingleOrDefault(s => s.SId == id);
                if (student == null)
                {
                    Console.WriteLine($"no such student id {id} exists ");
                }
                else
                {

                    Console.WriteLine("Student details as follows!!");
                    Console.WriteLine("Student id " + student.SId);
                    Console.WriteLine("Student name " + student.SName);
                    Console.WriteLine("Student price " + student.SFee);
                    Console.WriteLine("Student Date Of Birth" + student.SDob);
                    Console.WriteLine("\n");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
            finally
            {
                Console.ReadLine();

            }

        }

        private static void DeleteOperation()
        {
            try
            {
                db = new EntityFrameWorkEntities();
                Console.WriteLine("Enter Student id to delete Student");
                int id = int.Parse(Console.ReadLine());
                Student student = db.Students.SingleOrDefault(s => s.SId == id);
                if (student == null)
                {
                    Console.WriteLine($"no such student id {id} exists ");
                }
                else
                {

                   db.Students.Remove(student);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
            finally
            {
                Console.ReadLine();

            }
        }

        private static void UpdateOperation()
        {
            throw new NotImplementedException();
        }

        private static void InsertOperation()
        {
            throw new NotImplementedException();
        }
    }
}
