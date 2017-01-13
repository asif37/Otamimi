using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Otamimi.Models
{
   
    public class Refund : Request
    {
       
        public Payroll Payroll { get; set; }
        
        [Required]
        public string IBAN { get; set; }
        [Required]
        public string ToAccountHolderFullName { get; set; }

        
    }
}