using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworks
{
    internal class Program
    {
        static EntityFrameWorkEntities db;
        static Product product;
        static void Main(string[] args)
        {
            //try
            //{
            //    db= new EntityFrameWorkEntities();
            //    product = new Product();
            //    Console.WriteLine("Enter Product Id");
            //    product.PId = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Enter Product Name");
            //    product.PName = Console.ReadLine();
            //    Console.WriteLine("Enter Product Price");
            //    product.PPrice = double.Parse(Console.ReadLine());
            //    Console.WriteLine("Enter Product Manufacturing Date");
            //    product.MfgDate = DateTime.Parse(Console.ReadLine());
            //    db.Products.Add(product);
            //    db.SaveChanges();
            //    Console.WriteLine("Product registered successfully");

            //}

            //try
            //{
            //    db= new EntityFrameWorkEntities();
            //    foreach (var item in db.Products)
            //    {
            //        Console.WriteLine("Product ID " + item.PId);
            //        Console.WriteLine("Product Name " + item.PName);
            //        Console.WriteLine("Product Price " + item.PPrice);
            //        Console.WriteLine("Product Manufacturing Date " + item.MfgDate);
            //        Console.WriteLine("\n");
            //    }
            //}
            //try
            //{
            //    db = new EntityFrameWorkEntities();
            //    Console.WriteLine("Enter Product Id to search products");
            //    int id = int.Parse(Console.ReadLine());
            //    Product product = db.Products.SingleOrDefault(p => p.PId == id);
            //    if (product == null)
            //    {
            //        Console.WriteLine($"No Such Product Id {id} Exists ");
            //    }
            //    else
            //    {

            //        Console.WriteLine("Product Details as follows!!");
            //        Console.WriteLine("Product ID " + product.PId);
            //        Console.WriteLine("Product Name " + product.PName);
            //        Console.WriteLine("Product Price " + product.PPrice);
            //        Console.WriteLine("Product Manufacturing Date " + product.MfgDate);
            //        Console.WriteLine("Product Expiration Date " + product.ExpDate);
            //        Console.WriteLine("\n");

            //    }

            //}

            //try
            //{
            //    db = new EntityFrameWorkEntities();
            //    Console.WriteLine("Enter Product Id to delete the products");
            //    int id = int.Parse(Console.ReadLine());
            //    Product product = db.Products.SingleOrDefault(p => p.PId == id);
            //    if (product == null)
            //    {
            //        Console.WriteLine($"No Such Product Id {id} Exists ");
            //    }
            //    else
            //    {

            //        db.Products.Remove(product);
            //        db.SaveChanges();
            //        Console.WriteLine("Product Deleted!!");

            //    }

            //}

            //try
            //{
            //    db = new EntityFrameWorkEntities();
            //    Console.WriteLine("Enter Product Name to search products");
            //    string  name= Console.ReadLine();
            //    // Product product = db.Products.SingleOrDefault(p => p.PName== name);//give error for multiple values
            //    var prod = db.Products.Where(p => p.PName == name).ToList();
            //    Console.WriteLine("showing all products with given name through where Linq");
            //    foreach (var item in prod)
            //    {
            //        Console.WriteLine("Product Details as follows!!");
            //        Console.WriteLine("Product ID " + item.PId);
            //        Console.WriteLine("Product Name " + item.PName);
            //        Console.WriteLine("Product Price " + item.PPrice);
            //        Console.WriteLine("Product Manufacturing Date " + ((DateTime)item.MfgDate).ToShortDateString());
            //      //  Console.WriteLine("Product Expiry Date " + ((DateTime)item.ExpDate).ToShortDateString());

            //        Console.WriteLine("\n");
            //    }
            //    Console.WriteLine("showing name through FirstOrDefault");
            //    Product product = db.Products.FirstOrDefault(p => p.PName== name);//can show the first data if there are multiple values


            //    if (product == null)
            //    {
            //        Console.WriteLine($"No Such Product Name {name} Exists ");
            //    }
            //    else
            //    {

            //        Console.WriteLine("Product Details as follows!!");
            //        Console.WriteLine("Product ID " + product.PId);
            //        Console.WriteLine("Product Name " + product.PName);
            //        Console.WriteLine("Product Price " + product.PPrice);
            //        Console.WriteLine("Product Manufacturing Date " +((DateTime)product.MfgDate).ToShortDateString());
            //        Console.WriteLine("Product Expiry Date " +((DateTime)product.ExpDate).ToShortDateString());

            //        Console.WriteLine("\n");

            //    }



            //}

            try
            {
                db = new EntityFrameWorkEntities();
                Console.WriteLine("Enter Product Id to update product");
                int id = int.Parse(Console.ReadLine());
                Product product = db.Products.SingleOrDefault(p => p.PId == id);
                if (product == null)
                {
                    Console.WriteLine($"No Such Product Id {id} Exists ");
                }
                else
                {
                    Console.WriteLine("Enter new Product Name");
                    product.PName = Console.ReadLine();
                    Console.WriteLine("Enter new Product Price");
                    product.PPrice = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new Product Manufacturing Date");
                    product.MfgDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new Product Expiry Date");
                    product.ExpDate = DateTime.Parse(Console.ReadLine());
                    db.SaveChanges();
                    Console.WriteLine("Product Updated successfully");

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
    }
}
