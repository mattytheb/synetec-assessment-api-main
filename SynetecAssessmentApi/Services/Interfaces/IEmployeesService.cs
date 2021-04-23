using System.Collections.Generic;
using System.Threading.Tasks;
using SynetecAssessmentApi.Dtos;

namespace SynetecAssessmentApi.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
    }
}
