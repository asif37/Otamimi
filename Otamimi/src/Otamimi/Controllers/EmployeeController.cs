using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otamimi.Data;
using Otamimi.Manager;
using Microsoft.AspNetCore.Authorization;
using Shared.Web.MvcExtensions;

namespace Otamimi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ApplicantManager _applicantManager;
        private EmployeeManager _employeeManager;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
            _applicantManager = new ApplicantManager(_context);
            _employeeManager = new EmployeeManager(_context);
        }
        [Authorize(Roles ="Role1,Role2,Role3")]
        public IActionResult Dashboard()
        {
            var model = _applicantManager.GetAllRequests();
            return View(model);
        }
        public bool AcceptRequest(int Id,string Type)
        {
            if (Type== "Misfunds")
            {
                return _applicantManager.ChangeMisfundStatus(Id, Models.RequestStatus.Accepted, User.GetUserId());
            }
            else
            {
                return _applicantManager.ChangeRefundStatus(Id, Models.RequestStatus.Accepted, User.GetUserId());
            }
        }
        public bool ApproveRequest(int Id,string Type)
        {
            if (Type == "Misfunds")
            {
                return _applicantManager.ChangeMisfundStatus(Id, Models.RequestStatus.Approved, User.GetUserId());
            }
            else
            {
                return _applicantManager.ChangeRefundStatus(Id, Models.RequestStatus.Approved, User.GetUserId());
            }
        }
    }
}