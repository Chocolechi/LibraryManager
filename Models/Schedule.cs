using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
