using Dhruvesh_Practical_MM.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace Dhruvesh_Practical_MM.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly SqlConnection conn;

        public EmployeeRepo(SqlConnection sqlConnection)
        {
            conn = sqlConnection;
        }



        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                conn.Open();
                using (var cmd = new SqlCommand("SP_AddEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@c_empname", employee.c_empname);
                    cmd.Parameters.AddWithValue("@c_empemail", employee.c_empemail);
                    cmd.Parameters.AddWithValue("@c_empphone", employee.c_empphone);
                    cmd.Parameters.AddWithValue("@c_empaddress", employee.c_empaddress);
                    cmd.Parameters.AddWithValue("@c_empstate", employee.c_empstate);
                    cmd.Parameters.AddWithValue("@c_empcity", employee.c_empcity);
                    cmd.Parameters.AddWithValue("@c_createddate", DateTime.Now);


                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {

            try
            {
                conn.Open();
                List<EmployeeModel> list = new List<EmployeeModel>();
                using (var cmd = new SqlCommand("SP_GetAllEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeModel employee = new EmployeeModel
                            {
                                c_empid = Convert.ToInt32(reader["c_empid"]),
                                c_empname = reader["c_empname"].ToString(),
                                c_empemail = reader["c_empemail"].ToString(),
                                c_empphone = reader["c_empphone"].ToString(),
                                c_empaddress = reader["c_empaddress"].ToString(),
                                c_empstate = reader["c_statename"].ToString(),
                                c_empcity = reader["c_empcity"].ToString(),
                                c_createddate = reader.GetDateTime(reader.GetOrdinal("c_createddate"))
                            };

                            list.Add(employee);
                        }
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }


        }


        public EmployeeModel GetEmployeeById(int id)
        {

            try
            {
                conn.Open();

                using (var cmd = new SqlCommand("SP_GetEmployeeByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();


                        employee.c_empid = Convert.ToInt32(reader["c_empid"]);
                        employee.c_empname = reader["c_empname"].ToString();
                        employee.c_empemail = reader["c_empemail"].ToString();
                        employee.c_empphone = reader["c_empphone"].ToString();
                        employee.c_empaddress = reader["c_empaddress"].ToString();
                        employee.c_empstate = reader["c_empstate"].ToString();
                        employee.c_empcity = reader["c_empcity"].ToString();
                        employee.c_createddate = reader.GetDateTime(reader.GetOrdinal("c_createddate"));


                        return employee;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        

        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                conn.Open();
                using (var cmd = new SqlCommand("SP_UpdateEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@c_empname", employee.c_empname);
                    cmd.Parameters.AddWithValue("@c_empemail", employee.c_empemail);
                    cmd.Parameters.AddWithValue("@c_empphone", employee.c_empphone);
                    cmd.Parameters.AddWithValue("@c_empaddress", employee.c_empaddress);
                    cmd.Parameters.AddWithValue("@c_empstate", employee.c_empstate);
                    cmd.Parameters.AddWithValue("@c_empcity", employee.c_empcity);
                    cmd.Parameters.AddWithValue("@c_createddate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@c_empid", employee.c_empid);


                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                conn.Open();
                using (var cmd = new SqlCommand("SP_DeleteEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
