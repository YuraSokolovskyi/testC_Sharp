using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string connectionString = "Data Source=localhost;Initial Catalog=Test;Integrated Security=true;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);
            
            System.ConsoleKey key = ConsoleKey.P;
            while (key != ConsoleKey.Q)
            {
                Console.WriteLine("Connect: C\n" +
                                  "Disconnect: D\n" +
                                  "Show all info: A\n" +
                                  "Show all names: N\n" +
                                  "Show all average marks: V\n" +
                                  "Show all subject with min marks: M\n"
                                  );
                Console.Write("Your choice: ");
                key = Console.ReadKey().Key;
                Console.WriteLine("\n");

                try
                {
                    switch (key)
                    {
                        case ConsoleKey.C:
                            try
                            {
                                connection = new SqlConnection(connectionString);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            connection.Open();
                            Console.WriteLine("Connection successful");
                            break;
                        case ConsoleKey.D:
                            try
                            {
                                connection.Close();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            Console.WriteLine("Disconnected");
                            break;
                        case ConsoleKey.A:
                            try
                            {
                                string query = "SELECT * from StudentMarks";
                                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                                {
                                    Console.WriteLine(dataRow["firstName"]);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            break;
                        case ConsoleKey.N:
                            try
                            {
                                string query = "SELECT * from StudentMarks";
                                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                                {
                                    Console.WriteLine($"{dataRow["firstName"]}  {dataRow["lastName"]}  {dataRow["middleName"]}");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            break;
                        case ConsoleKey.V:
                            try
                            {
                                string query = "SELECT * from StudentMarks";
                                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                                {
                                    Console.WriteLine($"{dataRow["averageMark"]}");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            break;
                        case ConsoleKey.M:
                            try
                            {
                                string query = "SELECT minMarkSubject from StudentMarks WHERE minMarkSubject = (SELECT MIN(minMarkSubject) FROM StudentMarks)";
                                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                                DataSet dataSet = new DataSet();
                                adapter.Fill(dataSet);
                                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                                {
                                    Console.WriteLine($"{dataRow["minMarkSubject"]}");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                Console.WriteLine("\n");
            }
        }
    }
}