using Dhruvesh_Practical_MM.Models;
using Microsoft.Data.SqlClient;

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
                using(var cmd = new SqlCommand("select * from t_state",conn))
                {
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
        
    }
}
