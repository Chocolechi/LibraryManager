using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }

        //foreign key from employee to schedule
        [Display(Name = "Schedule")]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        [Display(Name = "Comission %")]
        public double Commission_percentage { get; set; }
        [Display(Name = "Start Day")]
        public DateTime StartDay { get; set; }

    }
}
