using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_Problem
{
    public class EmployeeRepository
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection sqlConnection = null;
        public static void GetAllEmployees()
        {
            try
            {
                EmployeePayroll model = new EmployeePayroll();
                sqlConnection = new SqlConnection(connectionString);
                string query = "select * from Employee_Payroll";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Connections is established successfully.....");

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
