using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace ConsoleAppADO
{
    class Program
    {
       static  SqlConnection connection;
       
       
        static string  GetConnectionString()
        {
    
            
            
            string connectionString = @"data source=LAPTOP-53S2KQS8\SQLEXPRESS;initial catalog=CGIPractice;integrated security=true";
            return connectionString;
        }
        static SqlConnection GetConnection()
        {
            
            connection = new SqlConnection(GetConnectionString());
            return connection;

        }
        static int MainMenu()
        {
            Console.WriteLine("MAIN MENU");

            Console.WriteLine("1. List of Employees");
            Console.WriteLine("2. Insert ");
            Console.WriteLine("3. Edit ");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Search ");
            Console.WriteLine("6. Exit ");
            Console.WriteLine("Enter yoir choice");
            int ch = Byte.Parse(Console.ReadLine());
            return ch;
        }
        static void Main(string[] args)
        {
            string choice = "y";
            int ch;
            while (choice == "y")
            {
                 ch = MainMenu();
                switch (ch)
                {
                    case 1: GetEmployees(); break;
                    case 2: InsertEmployee(); break;
                    case 3: EditEmployee(); break;
                    case 4: DeleteEmployee(); break;
                    case 5: SearchEmployee(); break;
                    default: Console.WriteLine("Invalid choice"); break;
                }
                Console.WriteLine("Do you want to cintinuue");
                choice = Console.ReadLine();
            }
        }

        static void GetEmployees()
        {
            connection = GetConnection();
            SqlCommand command = new SqlCommand("Select * from Employee", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                }
            }
            else

            {
                Console.WriteLine("There are no records");
            }
            connection.Close();
        }

        static void InsertEmployee()
        {

            connection = GetConnection();
            //SqlConnection connection = new SqlConnection(@"data source=LAPTOP-53S2KQS8\SQLEXPRESS;initial catalog=CGIPractice;integrated security=true");
            SqlCommand command = new SqlCommand("Insert into Employee (id, name, dept, salary) values (" +
                "100, 'Ajay','HR', 8999)", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }
        static void EditEmployee()
        {

            connection = GetConnection();
            //SqlConnection connection = new SqlConnection(@"data source=LAPTOP-53S2KQS8\SQLEXPRESS;initial catalog=CGIPractice;integrated security=true");
            SqlCommand command = new SqlCommand("update Employee set dept='Accts' where id=100", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        static void DeleteEmployee()
        {

            connection = GetConnection();
            //SqlConnection connection = new SqlConnection(@"data source=LAPTOP-53S2KQS8\SQLEXPRESS;initial catalog=CGIPractice;integrated security=true");
            SqlCommand command = new SqlCommand("delete Employee where id=100", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        static void SearchEmployee()
        {

            connection = GetConnection();
            //SqlConnection connection = new SqlConnection(@"data source=LAPTOP-53S2KQS8\SQLEXPRESS;initial catalog=CGIPractice;integrated security=true");
            SqlCommand command = new SqlCommand("Select * from Employee where id=100", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                
            }
            else

            {
                Console.WriteLine("There are no records");
            }
            connection.Close();

        }


    }

}

