using Otamimi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Otamimi.Models;
using Otamimi.Data;
using Microsoft.EntityFrameworkCore;

namespace Otamimi.Services.Repository
{
    public class ApplicantRepository : IApplicant
    {
        private readonly ApplicationDbContext _context;


        public ApplicantRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ApplicantRepository()
        {

        }
        public bool AddMisfundRequest(Misfund request)
        {
            try
            {
                _context.Misfunds.Add(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool AddRefundRequest(Refund request)
        {
            try
            {
                request.requiredDocument.Name = "Bank receipt";
                _context.Refunds.Add(request);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                
            }
           
        }

       
        public List<Misfund> GetMisfundByApplicantId(string applicantId)
        {
          return  _context.Misfunds.Where(s => s.ApplicantId == applicantId).Include(b => b.Applicant)
                .Include(b=> b.Bank).Include(b=> b.Country).Include(b => b.requiredDocument).ToList();
        }
        public List<Refund> GetrefundByApplicantId(string applicantId)
        {
            return _context.Refunds.Where(s => s.ApplicantId == applicantId).Include(b => b.Applicant)
                .Include(b => b.Bank).Include(b => b.Country).Include(b=>b.requiredDocument).ToList();
        }

        public Misfund GetMisfundById(int id)
        {
            return _context.Misfunds.Where(g => g.Id==id).FirstOrDefault();
        }

        public Refund GetRefundById(int id)
        {
            return _context.Refunds.Where(g => g.Id == id).FirstOrDefault();
        }

        public bool UpdateMisfundRequest(Misfund model)
        {
            var getMisfund = _context.Misfunds.Where(d => d.Id == model.Id).FirstOrDefault();
            getMisfund.BankId = model.Bank.Id;
            getMisfund.Amount = model.Amount;
            getMisfund.TransactionTime = model.TransactionTime;
            getMisfund.DepositorName = model.DepositorName;
            getMisfund.FromStudentNumber = model.FromStudentNumber;
            getMisfund.SourceAccountNumber = model.SourceAccountNumber;
            getMisfund.ToStudentNumber = model.ToStudentNumber;
            getMisfund.CountryId = model.Country.Id;
            _context.Misfunds.Update(getMisfund);
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           

        }

        public bool UpdateRefundRequest(Refund model)
        {
            var getRefund = _context.Refunds.Where(d => d.Id == model.Id).FirstOrDefault();
            getRefund.BankId = model.Bank.Id;
            getRefund.Amount = model.Amount;
            getRefund.TransactionTime = model.TransactionTime;
            getRefund.IBAN = model.IBAN;
            getRefund.ToAccountHolderFullName = model.ToAccountHolderFullName;
            getRefund.CountryId = model.Country.Id;
            _context.Refunds.Update(getRefund);
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool DelMisfundById(int id)
        {
            try
            {
                var getMisfundByid = _context.Misfunds.Where(f => f.Id == id).FirstOrDefault();
                _context.Misfunds.Remove(getMisfundByid);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DelRefundById(int id)
        {
            try
            {
                var getRefundByid = _context.Refunds.Where(f => f.Id == id).FirstOrDefault();
                _context.Refunds.Remove(getRefundByid);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Misfund> GetAllMisfund()
        {
            return _context.Misfunds.Include(b => b.Applicant)
               .Include(b => b.Bank).Include(b => b.Country).ToList();
        }

        public List<Refund> GetAllrefund()
        {
            return _context.Refunds.Include(b => b.Applicant)
               .Include(b => b.Bank).Include(b => b.Country).ToList();
        }

        public bool ChangeMisfundStatus(int id, RequestStatus status, string empId)
        {
            try
            {
                var getMisfund = _context.Misfunds.Where(f => f.Id == id).FirstOrDefault();
                getMisfund.EmployeeId = empId;
                getMisfund.Status = status;
                _context.Misfunds.Update(getMisfund);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ChangeRefundStatus(int id, RequestStatus status, string empId)
        {
            try
            {
                var getRefund = _context.Refunds.Where(f => f.Id == id).FirstOrDefault();
                getRefund.EmployeeId = empId;
                getRefund.Status = status;
                _context.Refunds.Update(getRefund);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool canCreateRequest(string Userid)
        {
            try
            {
                var getRefund = _context.Refunds.Where(f => f.ApplicantId==Userid).Any(s=>s.Status!=RequestStatus.Paid||s.Status!=RequestStatus.Rejected);
                var GetMisfunds= _context.Misfunds.Where(f => f.ApplicantId == Userid).Any(s => s.Status != RequestStatus.Paid || s.Status != RequestStatus.Rejected);
                if (getRefund|| GetMisfunds)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
