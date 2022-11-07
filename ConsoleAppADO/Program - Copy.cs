using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace ConsoleAppADO
{
    class Program1
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
                    case 1:
                        {
                          
                            
                            GetEmployees(); break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("ENter Dept");
                            string dept = Console.ReadLine();

                            Console.WriteLine("ENter Salry");
                            int salary = Int32.Parse(Console.ReadLine());
                            InsertEmployee(name, dept, salary); break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter ID for which to edit the record");
                            int id = Byte.Parse(Console.ReadLine());

                            Console.WriteLine("ENter Dept");
                            string dept = Console.ReadLine();

                            Console.WriteLine("ENter Salry");
                            int salary = Int32.Parse(Console.ReadLine()); EditEmployee(id, dept, salary); break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter ID for which to delete the record");
                            int id = Byte.Parse(Console.ReadLine()); DeleteEmployee(id); break;
                        }
                    case 5:
                        {
                            
                            Console.WriteLine("Enter ID for which to search the record");
                            int id = Byte.Parse(Console.ReadLine());
                            SearchEmployee(id); break;
                        }
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

        static void InsertEmployee(string name, string dept, int salary)
        {

            connection = GetConnection();
            //SqlConnection connection = new SqlConnection(@"data source=LAPTOP-53S2KQS8\SQLEXPRESS;initial catalog=CGIPractice;integrated security=true");
            SqlCommand command = new SqlCommand("Insert into Employee (name, dept, salary) values (@name, @dept, @salary)" , connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@dept", dept);
            command.Parameters.AddWithValue("@salary", salary);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }
        static void EditEmployee(int id, string dept, int salary)
        {

            connection = GetConnection();
            //SqlConnection connection = new SqlConnection(@"data source=LAPTOP-53S2KQS8\SQLEXPRESS;initial catalog=CGIPractice;integrated security=true");
            SqlCommand command = new SqlCommand("update Employee set dept=@dept, salary =@salary where id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@dept", dept);
            command.Parameters.AddWithValue("@salary", salary);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        static void DeleteEmployee(int id)
        {

            connection = GetConnection();
            //SqlConnection connection = new SqlConnection(@"data source=LAPTOP-53S2KQS8\SQLEXPRESS;initial catalog=CGIPractice;integrated security=true");
            SqlCommand command = new SqlCommand("delete Employee where id=@id", connection);
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        static void SearchEmployee(int id)
        {

            connection = GetConnection();
            //SqlConnection connection = new SqlConnection(@"data source=LAPTOP-53S2KQS8\SQLEXPRESS;initial catalog=CGIPractice;integrated security=true");
            SqlCommand command = new SqlCommand("Select * from Employee where id=@id", connection);
            command.Parameters.AddWithValue("@id", id);

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

