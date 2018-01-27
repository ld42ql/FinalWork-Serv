using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace FinalWork_Serv.Models
{

    public class SQLCommand
    {
        SqlConnection connection;

        public SQLCommand()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// Показать всю таблицу
        /// </summary>
        /// <returns></returns>
        public List<Employee> ViewList()
        {
            string sql = @"SELECT * FROM Employee";
            List<Employee> list = new List<Employee>();

            using (var com = new SqlCommand(sql, connection))
            {
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        list.Add(new Employee
                        {
                            ID = Convert.ToInt32(sdr[0]),
                            FIO = sdr[1].ToString(),
                            Salary = sdr[2].ToString(),
                            NameDepartmet = sdr[3].ToString()
                        });
                    }
                }
                com.ExecuteNonQuery();
            }
            return list;
        }

        /// <summary>
        /// Показать работника
        /// </summary>
        /// <param name="Id">Номер работника</param>
        /// <returns></returns>
        public Employee ViewEmployee(int Id)
        {
            Employee employee = new Employee();

            using (var com = new SqlCommand($@"SELECT * FROM Employee WHERE Id = {Id}", connection))
            {
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        employee = new Employee
                        {
                            ID = Convert.ToInt32(sdr[0]),
                            FIO = sdr[1].ToString(),
                            Salary = sdr[2].ToString(),
                            NameDepartmet = sdr[3].ToString()
                        };
                    }
                }
                com.ExecuteNonQuery();
            }
            
            return employee;
        }

        /// <summary>
        /// Добавить работника
        /// </summary>
        /// <param name="employee">Работник</param>
        public void InsertEmployee(Employee employee)
        {
            string sql = $@"
            INSERT INTO Employee (FIO, Salary, Department)
            VALUES (N'{employee.FIO}','{employee.Salary}',N'{employee.NameDepartmet}')";

            using (var com = new SqlCommand(sql, connection))
            {
                com.ExecuteNonQuery();
            }
        }
    }
}
