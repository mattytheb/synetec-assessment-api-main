using System;

namespace SynetecAssessmentApi.Domain
{
    public class Employee : Entity
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
