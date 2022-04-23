using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class Science
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
