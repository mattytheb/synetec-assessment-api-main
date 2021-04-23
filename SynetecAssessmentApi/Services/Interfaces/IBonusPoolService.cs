using System.Threading.Tasks;
using SynetecAssessmentApi.Dtos;

namespace SynetecAssessmentApi.Services.Interfaces
{
    public interface IBonusPoolService
    {
        Task<BonusPoolCalculatorResultDto> CalculateBonus(decimal bonusPoolAmount, int selectedEmployeeId);

        decimal GetBonusAllocation(decimal totalSalary, decimal employeeSalary, decimal bonusPoolAmount);
    }
}
