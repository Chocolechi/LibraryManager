using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class TypePerson
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
