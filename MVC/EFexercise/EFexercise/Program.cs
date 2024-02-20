using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFexercise
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
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        InsertOperation();
                        break;
                    case 2:
                        UpdateOperation();
                        break;
                    case 3:
                        DeleteOperation();
                        break;
                    case 4:
                        SearchOperation();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            Console.ReadLine();
            
        }

        public static void SearchOperation()
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
                    Display();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
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
                    Display();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
            
        }

        private static void UpdateOperation()
        {
            try
            {
                db = new EntityFrameWorkEntities();
                Console.WriteLine("Enter Student Id to update Student");
                int id = int.Parse(Console.ReadLine());
                Student product = db.Students.SingleOrDefault(p => p.SId == id);
                if (product == null)
                {
                    Console.WriteLine($"No Such Student Id {id} Exists ");
                }
                else
                {
                    Console.WriteLine("Enter new Student Name");
                    student.SName = Console.ReadLine();
                    Console.WriteLine("Enter new Student Fee");
                    student.SFee= double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new Student DOB");
                    student.SDob = DateTime.Parse(Console.ReadLine());
                   
                    db.SaveChanges();
                    Console.WriteLine("Student Updated successfully");

                    Console.WriteLine("\n");
                    Display();

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
            
        }

        private static void InsertOperation()
        {
            try
            {
                db = new EntityFrameWorkEntities();
                student = new Student();
                Console.WriteLine("Enter Student Id");
                student.SId= int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Student Name");
                student.SName = Console.ReadLine();
                Console.WriteLine("Enter Student Fee");
                student.SFee = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Student DOB");
                student.SDob = DateTime.Parse(Console.ReadLine());
                db.Students.Add(student);
                db.SaveChanges();
                Console.WriteLine("Student registered successfully");
                Display();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
            
        }

        private static void Display()
        {
            try
            {
                db = new EntityFrameWorkEntities();
                foreach (var item in db.Students)
                {
                    Console.WriteLine("Student ID " + item.SId);
                    Console.WriteLine("Student Name " + item.SName);
                    Console.WriteLine("Student Fee " + item.SFee);
                    Console.WriteLine("Student Date of birth " + item.SDob);
                    Console.WriteLine("\n");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
           
        }
    }
}
