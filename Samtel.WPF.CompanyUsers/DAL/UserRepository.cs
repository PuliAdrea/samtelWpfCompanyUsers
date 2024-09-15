using Samtel.WPF.CompanyUsers.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace Samtel.WPF.CompanyUsers.DAL
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository() 
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;
        }


        public void CreateUser(string firstName, string lastName, string email, string phone) 
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CreateUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<User> GetUsers() 
        {
            List<User> users = new List<User>();
            using (var conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetLast10Users", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        User user = new User()
                        {
                            UserId = Convert.ToInt32(sqlDataReader["user_id"]),
                            FirstName = sqlDataReader["first_name"].ToString(),
                            LastName = sqlDataReader["last_name"].ToString(),
                            Email = sqlDataReader["email"].ToString(),
                            Phone = sqlDataReader["phone"].ToString()
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public void UpdateUser(User user) 
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
    }
    
}
