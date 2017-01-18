using Otamimi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otamimi.Services.Interface
{
    public interface IApplicant
    {
       
        bool AddRefundRequest(Refund request);
        bool AddMisfundRequest(Misfund request);
        List<Misfund> GetMisfundByApplicantId(string applicantId);
        List<Refund> GetrefundByApplicantId(string applicantId);
        List<Misfund> GetAllMisfund();
        List<Refund> GetAllrefund();
        Misfund GetMisfundById(int id);
        Refund GetRefundById(int id);
        bool UpdateMisfundRequest(Misfund model);
        bool UpdateRefundRequest(Refund model);
        bool DelMisfundById(int id);
        bool DelRefundById(int id);
        bool ChangeMisfundStatus(int id, RequestStatus status,string empId);
        bool ChangeRefundStatus(int id, RequestStatus status, string empId);
        bool canCreateRequest(string Userid);

    }
}
