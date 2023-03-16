using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_Problem
{
    public class EmployeeRepository
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection sqlConnection = null;
        /// <summary>
        /// UC-2 Retrieve employees data.
        /// </summary>
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
                //Console.WriteLine("Connections is established successfully.....");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.Id = Convert.ToInt32(reader["Id"] == DBNull.Value ? default : reader["Id"]);
                        model.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                        model.Basic_Pay = Convert.ToInt64(reader["Basic_Pay"] == DBNull.Value ? default : reader["Basic_Pay"]);
                        model.StartDate = (DateTime)(reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]);

                        model.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                        model.Phone_Number = Convert.ToInt64(reader["Phone_Number"] == DBNull.Value ? default : reader["Phone_Number"]);
                        model.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                        model.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                        model.Deductions = Convert.ToInt64(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);
                        model.Taxable_Pay = Convert.ToInt64(reader["Taxable_Pay"] == DBNull.Value ? default : reader["Taxable_Pay"]);
                        model.Income_Tax = Convert.ToInt64(reader["Income_Tax"] == DBNull.Value ? default : reader["Income_Tax"]);
                        model.Net_Pay = Convert.ToInt64(reader["Net_Pay"] == DBNull.Value ? default : reader["Net_Pay"]);
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", model.Id, model.Name, model.Basic_Pay, model.StartDate, model.Gender, model.Phone_Number, model.Address, model.Department, model.Deductions, model.Taxable_Pay, model.Income_Tax, model.Net_Pay);
                    }
                }

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

        /// <summary>
        /// UC3-Ability to update the salary i.e. the Basic_Pay for Employee Terisa to 3000000.00
        /// </summary>
        /// <param name="model"></param>
        public static void UpdateEmployee(EmployeePayroll model)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spUpdateEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                command.Parameters.AddWithValue("@Id", model.Id);
                int num = command.ExecuteNonQuery();
                if (num != 0)

                    Console.WriteLine("Employee Updated Successfully");
                else
                    Console.WriteLine("Something went Wrong");
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

        /// <summary>
        /// UC4- Add new employees data
        /// </summary>
        /// <param name="model"></param>
        public static void AddEmployee(EmployeePayroll model)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spAddNewEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                command.Parameters.AddWithValue("@Phone_Number", model.Phone_Number);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.AddWithValue("@Department", model.Department);
                int num = command.ExecuteNonQuery();
                if (num != 0)
                    Console.WriteLine("Employee Added Successfully");
                else
                    Console.WriteLine("Something went Wrong");
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
        /// <summary>
        /// UC5- Delete employee 
        /// </summary>
        /// <param name="model"></param>
        public static void DeleteEmployee(EmployeePayroll model)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spDeleteEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Id", model.Id);
                int num = command.ExecuteNonQuery();
                if (num != 0)
                    Console.WriteLine("Employee Delete Successfully");
                else
                    Console.WriteLine("Something went Wrong");
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
