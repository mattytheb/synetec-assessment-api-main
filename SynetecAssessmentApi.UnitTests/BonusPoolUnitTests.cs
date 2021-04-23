using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using SynetecAssessmentApi.Services;
using Xunit;

namespace SynetecAssessmentApi.UnitTests
{
    public class BonusPoolUnitTests
    {
        [Theory]
        [BonusPoolServiceAutoData]
        public void CalculateBonusAsync_PooledBonus300_ShouldReturnWithAmountSet(BonusPoolService sut, int employeeId)
        {
            var taskResult = sut.CalculateBonus(300, employeeId);

            taskResult.Result.Amount.Should().Be(100);
        }

        [Theory]
        [BonusPoolServiceAutoData]
        public void CalculateBonusAsync_PooledBonusOddAmount_ShouldReturnAmountSet2DecimalPlaces(BonusPoolService sut, int employeeId)
        {
            var taskResult = sut.CalculateBonus(14, employeeId);

            taskResult.Result.Amount.Should().Be(4.67M);
        }

        [Theory]
        [BonusPoolServiceAutoData]
        public void CalculateBonusAsync_PooledBonusZeroAmount_ShouldReturnZero(BonusPoolService sut, int employeeId)
        {
            var taskResult = sut.CalculateBonus(0, employeeId);

            taskResult.Result.Amount.Should().Be(0);
        }

        [Theory]
        [BonusPoolInlineAutoData(1000, 200, 100, 20)]
        [BonusPoolInlineAutoData(1000, 0, 100, 0)]
        [BonusPoolInlineAutoData(1000, 200, 0, 0)]
        [BonusPoolInlineAutoData(100_000_000, 20_000_000, 1_000_000, 200_000)]
        public void GetBonusAllocation_SetSalaryTotal_ShouldReturnExpectedAmount(decimal totalSalary, decimal employeeSalary, decimal bonusPoolAmount, decimal expectedAmount,
            BonusPoolService sut)
        {
            var result = sut.GetBonusAllocation(totalSalary, employeeSalary, bonusPoolAmount);

            result.Should().Be(expectedAmount);
        }

        [Theory]
        [BonusPoolInlineAutoData(0, 200, 100)]
        public void GetBonusAllocation_ShouldThrowException(decimal totalSalary, decimal employeeSalary, decimal bonusPoolAmount, BonusPoolService sut)
        {
            Action action = () =>  sut.GetBonusAllocation(totalSalary, employeeSalary, bonusPoolAmount);

            action.Should().Throw<Exception>().WithMessage($"Total Salary of {totalSalary} too low.");
        }
    }
}
