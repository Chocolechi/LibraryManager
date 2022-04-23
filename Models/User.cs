using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManager.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        
        [Display(Name = "License")]
        public string LicenseNumber { get; set; }

        [Display(Name = "Type Person")]
        public int TypePersonId { get; set; }
        public TypePerson TypePerson { get; set; }
        [NotMapped]
        public List<SelectListItem> TypePeople { get; set; }

    }
}
