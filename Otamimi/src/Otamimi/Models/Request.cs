using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Otamimi.Models
{
    public class Request
    {
        public Request()
        {
            Applicant = new ApplicationUser();
            Employee = new ApplicationUser();
            Country = new Country();
            Bank = new Bank();
            requiredDocument = new RequiredDocument();
        }
        [Key]
        public int Id { get; set; }
        
        public string ApplicantId { get; set; }
        [Required]
        public virtual ApplicationUser Applicant { get; set; }

        // [Required]
        public string  EmployeeId { get; set; }
        public virtual ApplicationUser Employee { get; set; }

        [Required]
        public RequestStatus Status { get; set; }

        [Required]
        public RequestType Type { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public List<Note> Notes { get; set; }

        [Required]
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }

        public DateTime TransactionTime { get; set; }

        [Required]
        public virtual Bank Bank { get; set; }
        public int BankId { get; set; }

        // public file Type1 { get; set; }
        public int RequiredDocumentId { get; set; }
        public virtual RequiredDocument requiredDocument { get; set; }


    }
}
