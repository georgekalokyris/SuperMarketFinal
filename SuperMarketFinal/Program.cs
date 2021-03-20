using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckout
{
    public class CashRegister
    {

        //List of products
        public List<Product> Products = new List<Product>();

        //Total Price 
        public double TotalPrice;

        //Scan Void Method to add products to the list
        public void Scan(Product prod)
        { 

            Products.Add(prod);
            TotalPrice += prod.Price; //TotalPrice
        }

        public void Receipt()
        {
            foreach (var item in Products)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(item);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        public void PrintItem(Product item)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine(item);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }



    }

    public class Product
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public int Quantity { get; set; }
        

        //Function that returns string of the ProductName + Price + Weight (+ Check for duplicate products)
        public override string ToString()
        {
            return ($"{ProductName} \t \t {Quantity} \t \t {Weight} \t \t {Price}");
        }
        public Product(string Name, double Price, int Quantity = 1) //1 item by default
        {
            ProductName = Name;
            this.Price = Price * Quantity;
            this.Quantity = Quantity;

        }

        public Product(string Name, double Price, double Weight = 1) //1kg by default
        {
            ProductName = Name;
            this.Price = Price * Weight;
            this.Weight = Weight;
        }
       
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Welcome to the Checkout");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            CashRegister Reg = new CashRegister();

            
            Menu(Reg);
            
           
            
        }

        public static void Menu(CashRegister Reg)
        {

            

            bool Cont = true;
            while (Cont)
            {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Press 1 to Scan products");
            Console.WriteLine("Press 2 to view the current total price");
            Console.WriteLine("Press any key to Checkout");
            
                switch (Console.ReadLine())
                {
                    case "1":
                        AddProducts(Reg);
                        continue;

                    case "2":
                        Console.WriteLine($"Total items sacnned: {Reg.Products.Count}");
                        Console.WriteLine($"TotalPrice for the scanned products is: {Reg.TotalPrice} £");
                        continue;

                    default:
                        //Print Receipt Method
                        Checkout(Reg);
                        Cont = false;
                        break;

                }
            }

        }

        private static void Checkout(CashRegister Reg)
        {
            Console.WriteLine("-------------------------------------RECEIPT------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("ProductName \t   Quantity  \t Weight  \t Price");

            Reg.Receipt();
            Console.WriteLine($"Total Price: {Reg.TotalPrice}");

        }

        public static void AddProducts(CashRegister Reg)
        {


            bool cont = true;
            while (cont) {
                Console.WriteLine("Please define the product's name");
                string ProductName = Console.ReadLine();

                Console.WriteLine("Please define the product's price per item/kg");
                double Product = double.Parse(Console.ReadLine());

                Console.WriteLine("Please define the product's weight");
                double Weight = double.Parse(Console.ReadLine());

                if (Weight > 0) 
                {
                    Reg.Scan(new Product(ProductName, Product, Weight));


                    Console.WriteLine("ProductName \t   Quantity \t Weight \t Price");
                    Reg.PrintItem(new Product(ProductName, Product, Weight));

             
                }
                else 
                {
                    Console.WriteLine("Please define the quantity of the product");
                    int Quant = int.Parse(Console.ReadLine());
                    Reg.Scan(new Product(ProductName, Product, Quant));


                    Console.WriteLine("ProductName \t  Quantity \t Weight \t Price");
                    Reg.PrintItem(new Product(ProductName, Product, Quant));


                }


                Console.WriteLine("Press Enter to continue or type EXIT to return to the main menu");
                string Option = Console.ReadLine();

                if (Option == "EXIT")
                {
                    cont = false;
                }
               


            }

        }
    }
}
