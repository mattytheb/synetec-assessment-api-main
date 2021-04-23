using System.Threading.Tasks;
using AutoFixture;
using Moq;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Repository;

namespace SynetecAssessmentApi.UnitTests
{
    public class BonusPoolServiceCustomisation : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.OmitAutoProperties = true;

            var testEmployee = fixture.Build<Employee>()
                .With(x => x.Fullname, "Jon Test")
                .With(x => x.Salary, 1000)
                .Create();

            var appRepositoryMock = new Mock<IAppRepository>();

            appRepositoryMock
                .Setup(x => x.GetEmployeeAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(testEmployee));

            appRepositoryMock
                .Setup(x => x.GetTotalOfCompanySalaries())
                .Returns(3000M);

            fixture.Inject(appRepositoryMock);
        }
    }
}
