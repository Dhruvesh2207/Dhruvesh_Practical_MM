using Dhruvesh_Practical_MM.Models;

namespace Dhruvesh_Practical_MM.Repositories
{
    public interface IStateCityRepo
    {
        IEnumerable<StateModel> GetAllState();
    }
}
