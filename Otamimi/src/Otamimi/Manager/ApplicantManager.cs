using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Otamimi.ViewModels;
using Otamimi.Services.Interface;
using Otamimi.Services.Repository;
using Otamimi.Models;
using Otamimi.Data;

namespace Otamimi.Manager
{
    public class ApplicantManager
    {
        private IApplicant _applicant;
        public ApplicantManager(ApplicationDbContext context)
         {
            _applicant = new ApplicantRepository(context);
        }
        public bool AddRequest(RequestViewModel model,string Userid,string fileName)
        {
            if (model.RequestType == "refund")
            {
                Refund refnd = new Refund();
                refnd.Applicant = null;
                refnd.ApplicantId = Userid;
                refnd.Amount = model.refund.Amount;               
                refnd.BankId = model.refund.Bank.Id;
                refnd.Bank = null;
                refnd.Country = null;
                refnd.IBAN = model.refund.IBAN;
                refnd.ToAccountHolderFullName = model.refund.ToAccountHolderFullName;
                refnd.CountryId = model.refund.Country.Id;
                refnd.TransactionTime = model.refund.TransactionTime;
                refnd.Type = RequestType.Refund;
                refnd.Status = RequestStatus.Recieved;
                refnd.requiredDocument = new RequiredDocument();
                refnd.requiredDocument.Name = "bank reciept";
                refnd.requiredDocument.DocImagePath = fileName;
                return _applicant.AddRefundRequest(refnd);
                //return refnd;


            }
            else
            {
                Misfund Misfund = new Misfund();
                Misfund.ApplicantId = Userid;
                Misfund.Bank = null;
                Misfund.Country = null;
                Misfund.Applicant = null;
                Misfund.Amount = model.misFunds.Amount;
                Misfund.BankId = model.misFunds.Bank.Id;
                Misfund.DepositorName = model.misFunds.DepositorName;
                Misfund.SourceAccountNumber = model.misFunds.SourceAccountNumber;
                Misfund.CountryId = model.misFunds.Country.Id;
                Misfund.TransactionTime = model.refund.TransactionTime;
                Misfund.FromStudentNumber = model.misFunds.FromStudentNumber;
                Misfund.ToStudentNumber = model.misFunds.ToStudentNumber;
                Misfund.Type = RequestType.MisFund;
                Misfund.Status = RequestStatus.Recieved;
                Misfund.requiredDocument = new RequiredDocument();
                Misfund.requiredDocument.DocImagePath = fileName;
                Misfund.requiredDocument.Name = "bank reciept";
                return _applicant.AddMisfundRequest(Misfund);
                //return new Refund();
            }



        }
        public RequestViewModel GetAllRequestByApplicantId(string ApplicantId)
        {
            var model = new RequestViewModel();
            model.MisfundsList = _applicant.GetMisfundByApplicantId(ApplicantId);
            model.refundList = _applicant.GetrefundByApplicantId(ApplicantId);
            return model;
        }
        public Misfund GetMisfundById(int id)
        {
           return  _applicant.GetMisfundById(id);
        }
        public Refund GetRefundById(int id)
        {
            return _applicant.GetRefundById(id);
        }
        public bool UpdateMisfundRequest(Misfund model)
        {
            return _applicant.UpdateMisfundRequest(model);
        }
        public bool UpdateRefundRequest(Refund model)
        {
            return _applicant.UpdateRefundRequest(model);
        }
        public bool DelMisfundById(int id)
        {
            return _applicant.DelMisfundById(id);
        }
        public bool DelRefundById(int id)
        {
            return _applicant.DelRefundById(id);
        }
        public RequestViewModel GetAllRequests()
        {
            var model = new RequestViewModel();
            model.MisfundsList = _applicant.GetAllMisfund();
            model.refundList = _applicant.GetAllrefund();
            return model;
        }
        public bool ChangeMisfundStatus(int id,RequestStatus status,string EmpId)
        {
            return _applicant.ChangeMisfundStatus(id, status, EmpId);
        }
        public bool ChangeRefundStatus(int id,RequestStatus status, string EmpId)
        {
            return _applicant.ChangeRefundStatus(id, status, EmpId);
        }
        public bool canCreateRequest(string UserId)
        {
            return _applicant.canCreateRequest(UserId);
        }
    }
}
