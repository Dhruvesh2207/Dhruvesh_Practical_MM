using Dhruvesh_Practical_MM.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dhruvesh_Practical_MM.Repositories
{
    public class StateCityRepo : IStateCityRepo
    {
        private readonly SqlConnection conn;

        public StateCityRepo(SqlConnection sqlConnection)
        {
            conn = sqlConnection;
        }

        

        public IEnumerable<StateModel> GetAllState()
        {
            try
            {
                conn.Open();
                List<StateModel> list  = new List<StateModel>();
                using(var cmd = new SqlCommand("SP_GetAllState", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StateModel state = new StateModel();
                        state.c_stateid = Convert.ToInt32(reader["c_stateid"]);
                        state.c_statename = reader["c_statename"].ToString();

                        list.Add(state);
                    }
                    return list;
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public IEnumerable<CityModel> GetCityByState(int stateid)
        {
            try
            {
                conn.Open();
                List<CityModel> list = new List<CityModel>();
                using(var cmd  = new SqlCommand("SP_GetCityByState", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", stateid);
                    var reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        CityModel city = new CityModel();
                        city.c_cityid = Convert.ToInt32(reader["c_cityid"]);
                        city.c_cityname = reader["c_cityname"].ToString();
                        city.c_stateid = Convert.ToInt32(reader["c_stateid"]);

                        list.Add((city));
                    }
                    return list;
                }
            }
            catch(Exception ex)
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
