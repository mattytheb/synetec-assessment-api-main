using AutoMapper;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;

namespace SynetecAssessmentApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>()
                .ForMember(dto => dto.Id, opts => opts.Ignore())
                .ForMember(dto => dto.DepartmentId, opts => opts.Ignore())
                .ForMember(dto => dto.Fullname, opts => opts.MapFrom(s => s.Fullname))
                .ForMember(dto => dto.JobTitle, opts => opts.MapFrom(s => s.JobTitle))
                .ForMember(dto => dto.Salary, opts => opts.MapFrom(s => s.Salary))
                .ForMember(dto => dto.Department, opts => opts.MapFrom(s => s.Department))
                .ReverseMap();

            CreateMap<DepartmentDto, Department>()
                .ForMember(dto => dto.Id, opts => opts.Ignore())
                .ForMember(dto => dto.Title, opts => opts.MapFrom(s => s.Title))
                .ForMember(dto => dto.Description, opts => opts.MapFrom(s => s.Description))
                .ReverseMap();

            CreateMap<BonusPoolCalculatorResultDto, Employee>()
                .ForMember(dto => dto.Fullname, opts => opts.MapFrom(s => s.Employee.Fullname))
                .ForMember(dto => dto.JobTitle, opts => opts.MapFrom(s => s.Employee.JobTitle))
                .ForMember(dto => dto.Department, opts => opts.MapFrom(s => s.Employee.Department))
                .ForMember(dto => dto.Salary, opts => opts.MapFrom(s => s.Employee.Salary))
                .ReverseMap();

        }
    }
}
