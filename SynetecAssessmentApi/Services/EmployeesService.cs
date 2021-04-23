using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Repository;
using SynetecAssessmentApi.Services.Interfaces;

namespace SynetecAssessmentApi.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IAppRepository _repository;
        private readonly IMapper _mapper;

        public EmployeesService(IAppRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await _repository.GetAllEmployeesAsync();

            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        }
    }
}
