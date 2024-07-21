using Dhruvesh_Practical_MM.Models;

namespace Dhruvesh_Practical_MM.Repositories
{
    public interface IEmployeeRepo
    {
        void AddEmployee(EmployeeModel employeeModel);
        IEnumerable<EmployeeModel> GetAllEmployee();

        public EmployeeModel GetEmployeeById(int id);
        void UpdateEmployee(EmployeeModel employeeModel);
        void DeleteEmployee(int id);

        
    }
}
