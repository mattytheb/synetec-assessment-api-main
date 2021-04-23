using System;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using System.Threading.Tasks;
using AutoMapper;
using SynetecAssessmentApi.Repository;
using SynetecAssessmentApi.Services.Interfaces;

namespace SynetecAssessmentApi.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        private readonly IAppRepository _repository;
        private readonly IMapper _mapper;

        public BonusPoolService(IAppRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BonusPoolCalculatorResultDto> CalculateBonus(decimal bonusPoolAmount, int selectedEmployeeId)
        {
            var employee = await _repository.GetEmployeeAsync(selectedEmployeeId);

            if (employee == null)
            {
                throw new SynetecAssessmentException("Employee not found");
            }

            var totalSalary = _repository.GetTotalOfCompanySalaries();

            var bonusAllocation = GetBonusAllocation(totalSalary, employee.Salary, bonusPoolAmount);

            var result = _mapper.Map<Employee, BonusPoolCalculatorResultDto>(employee);

            result.Amount = decimal.Round(bonusAllocation, 2);

            return result;
        }

        public decimal GetBonusAllocation(decimal totalSalary, decimal employeeSalary, decimal bonusPoolAmount)
        {
            if (totalSalary < 1)
            {
                throw new SynetecAssessmentException($"Total Salary of {totalSalary} too low.");
            }

            var bonusAllocationForEmployee = employeeSalary / totalSalary;

            return bonusAllocationForEmployee * bonusPoolAmount;
        }
    }
}
