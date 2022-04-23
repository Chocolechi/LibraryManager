using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class LoanAndRepayment
    {
        [Key]
        public int Id { get; set; }

        
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        [Display(Name = "Loan Date")]
        public DateTime LoanDate { get; set; }

        public double PriceXDayExceed { get; set; }
        public int AmountOfDays { get; set; }

        public string Comments { get; set; }

    }
}
