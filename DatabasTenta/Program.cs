using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DatabasTenta
{
    class Program
    {
        static void Main(string[] args)
        {
            StartApp();
        }

        static void StartApp()
        {
            int option = 0;

            Console.WriteLine("\n" + "What would you like to do?" + "\n");
            Console.WriteLine("1. See Orders by Company name.");
            Console.WriteLine("2. See Total Freight Cost by Shipper.");
            Console.WriteLine("3. ...");
            Console.WriteLine("4. ...");
            Console.WriteLine("5. ...");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter the Company Name: ");
                    OrdersByCustomerCompanyName(Console.ReadLine());
                    break;
            }

            }

        static string OrdersByCustomerCompanyName(string CompanyName)
        {
            //string cName = CompanyName;

            string conString = ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
            SqlConnection cn = new SqlConnection(conString);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();

            //cmd.CommandText = "select CustomerID, ContactName from Customers";
            cmd.CommandText = "select CompanyName, OrderID from Customers, Orders where Customers.CustomerID = orders.CustomerID";
            cmd.ExecuteNonQuery();
            
            //Vad menas med "orderrader för respektive order"? Är det antalet beställningar per produkt (per kund) eller
            //är det antalet produkter per beställning (per kund)? 

            return CompanyName; //Provisorisk, inte färdig...
        }

        static void FreightByShipper()
        {

        }
    }
}
