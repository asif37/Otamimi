using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Otamimi.Models;

namespace Otamimi.ViewModels
{
    public class RequestViewModel
    {
        public Misfund misFunds { get; set; }
        public Refund refund { get; set; }
        public string RequestType { get; set; }
        public List<Misfund> MisfundsList { get; set; }
        public List<Refund> refundList { get; set; }
        public RequiredDocument doc { get; set; }
    }
}
