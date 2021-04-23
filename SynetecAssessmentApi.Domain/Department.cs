using System.Collections.Generic;

namespace SynetecAssessmentApi.Domain
{
    public class Department : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
