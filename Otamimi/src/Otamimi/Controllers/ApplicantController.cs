using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otamimi.Data;
using Microsoft.EntityFrameworkCore;
using Otamimi.ViewModels;
using Otamimi.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Otamimi.Manager;
using Shared.Web.MvcExtensions;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Otamimi.Controllers
{
    [Authorize(Roles ="Applicant")]
    public class ApplicantController : Controller
    {
        private string UserId;
        private readonly ApplicationDbContext _context;
        private ApplicantManager _applicantManager;
        private IHostingEnvironment _environment;
        public ApplicantController( ApplicationDbContext context, IHostingEnvironment environment)
        {          
            _context = context;
            _applicantManager = new ApplicantManager(_context);
            _environment = environment;
        }


       
        public IActionResult Index()
        {
            ViewBag.BanksList = _context.Banks.ToList();
            ViewBag.CountryList = _context.Countries.ToList();
            return View(new RequestViewModel());

        }
        [HttpPost]
        public ActionResult CreateRequest(RequestViewModel model, IFormFile file)
        {
            var fileName = "";
            if (file.Length > 0)
            {
                fileName = Guid.NewGuid().ToString()+".png";
                var uploads = Path.Combine(_environment.WebRootPath, "BankImages");
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }
                
            }
            var request = _applicantManager.AddRequest(model,User.GetUserId(),fileName);
            return RedirectToAction("Dashboard");
        }
      
        public IActionResult Dashboard()

        {
            var userid = User.GetUserId();
            var GetRequests = _applicantManager.GetAllRequestByApplicantId(userid);
            return View(GetRequests);
        }
        public ActionResult EditMisfunds(int Id)
        {
            ViewBag.BanksList = _context.Banks.ToList();
            ViewBag.CountryList = _context.Countries.ToList();
            var model = new RequestViewModel();
            model.misFunds= _applicantManager.GetMisfundById(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditMisfunds(RequestViewModel model)
        {
            _applicantManager.UpdateMisfundRequest(model.misFunds);
            return RedirectToAction("Dashboard");
        }
        public ActionResult EditRefunds(int Id)
        {
            ViewBag.BanksList = _context.Banks.ToList();
            ViewBag.CountryList = _context.Countries.ToList();
            var model = new RequestViewModel();
            model.refund = _applicantManager.GetRefundById(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditRefunds(RequestViewModel model)
        {
            _applicantManager.UpdateRefundRequest(model.refund);
            return RedirectToAction("Dashboard");
        }
        public bool DeleteMisfunds(int Id)
        {

            return _applicantManager.DelMisfundById(Id);
        }
        public bool DeleteRefunds(int Id)
        {
            return _applicantManager.DelRefundById(Id);
        }
    }
}