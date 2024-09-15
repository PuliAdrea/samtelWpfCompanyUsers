using Samtel.WPF.CompanyUsers.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Samtel.WPF.CompanyUsers.DAL
{
    public class DepartmentRepository
    {
        private readonly string _connectionString;
        public DepartmentRepository() 
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;
        }

        public List<Department> GetDepartments() 
        {
            List<Department> result = new List<Department>();
            using (var conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetDepartments", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Department department = new Department()
                        {
                            DepartmentId = Convert.ToInt32(sqlDataReader["department_id"]),
                            DepartmentName = sqlDataReader["department_name"].ToString(),
                        };
                        result.Add(department);
                    }
                }
            }
            return result;
        }

        public void AssignUserToDepartment(int userId, int departmentId) 
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AssignUserToDepartment", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
