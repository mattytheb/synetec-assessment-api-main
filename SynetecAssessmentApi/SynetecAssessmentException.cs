using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi
{
    public class SynetecAssessmentException : Exception
    {
        public SynetecAssessmentException(string message)
            : base(message)
        {
        }
    }
}
