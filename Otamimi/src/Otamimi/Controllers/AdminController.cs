using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otamimi.Data;
using Microsoft.EntityFrameworkCore;
using Otamimi.ViewModels;

namespace Otamimi.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Dashboard()
        {
             var rolesList = _context.Roles.ToList();
            var userlist = _context.Users.Include(d => d.Roles).Include(d => d.Claims).Where(d=>d.Roles.Count>0).ToList().Select(s => new UserViewModel
            {
                Email = s.Email, FullName = s.FullName, MobileNo = s.MobileNumber, Username = s.UserName, Role = rolesList.Where(role => role.Id == s.Roles.FirstOrDefault().RoleId).FirstOrDefault().Name

            }).ToList();         
            return View(userlist);
        }
    }
}