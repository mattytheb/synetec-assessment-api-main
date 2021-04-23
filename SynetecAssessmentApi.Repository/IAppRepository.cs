using System.Collections.Generic;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Repository
{
    public interface IAppRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int employeeId);
        decimal GetTotalOfCompanySalaries();
    }
}
