using Otamimi.Data;
using Otamimi.Services.Interface;
using Otamimi.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otamimi.Manager
{
    public class EmployeeManager
    {
        private IApplicant _applicant;
        public EmployeeManager(ApplicationDbContext context)
        {
            _applicant = new ApplicantRepository(context);
        }
    }
}
