using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otamimi.Models
{
   
    public enum RequestStatus
    {
        Recieved,
        Accepted,
        Approved,
        Paid,
        Rejected,
        Canceled
    }
}
