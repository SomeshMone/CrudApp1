using System;
using System.Data.SqlClient;
namespace CrudApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=LAPTOP-HFJ7MFRU\SQLEXPRESS;Initial Catalog=CoDb;Integrated Security=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Connection Successful");
                string answer;
                do
                {
                    Console.WriteLine("Select from the options below \n1. Creation\n2. Retrieve\n3. Update\n4. Delete");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        // Create => C
                        case 1:
                            Console.WriteLine("Enter student id");
                            int st_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter student name");
                            string st_name = Console.ReadLine();
                            Console.WriteLine("Enter student age");
                            int st_age = int.Parse(Console.ReadLine());
                            string inserQuery = "insert into Student(student_id,student_name,age) values(" + st_id + ",'" + st_name + "'," + st_age + ")";
                            SqlCommand insertCommand = new SqlCommand(inserQuery, sqlConnection);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Insertion Successfull");
                            break;
                        case 2:
                            string displayQuery = "select * from  Student";
                            SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                            SqlDataReader dataReader = displayCommand.ExecuteReader();
                            while (dataReader.Read())
                            {
                                Console.WriteLine("Student_Id: " + dataReader.GetValue(0));
                                Console.WriteLine("Student_Name: " + dataReader.GetValue(1));
                                Console.WriteLine("Student_Age: " + dataReader.GetValue(2));
                            }
                            dataReader.Close();
                            break;
                        case 3:
                            Console.WriteLine("Enter user student_id that you want to update:");
                            int s_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter user age to update:");
                            int s_age = int.Parse(Console.ReadLine());
                            string updateQuery = "UPDATE Student SET age = " + s_age + " WHERE student_id = " + s_id;
                            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Update Successful");
                            break;
                        case 4:
                            Console.WriteLine("Enter user student id you want to delete from table:");
                            int user_id = int.Parse(Console.ReadLine());
                            string deleteQuery = "DELETE FROM Student WHERE student_id = " + user_id;
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Deletion Successful");
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;

                    }
                    Console.WriteLine("Do you want to continue? (Yes)");
                    answer = Console.ReadLine();
                } while (answer.ToLower() == "yes");
                   

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}