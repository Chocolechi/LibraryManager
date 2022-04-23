using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ISBN { get; set; }

        //Foreign Key for Bibliografy
        [Display(Name = "Bibliography")]
        public int BibliographyId { get; set; }
        public Bibliography Bibliography { get; set; }

        //Fereign Key for Author
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        //Foreign Key for Editorial
        [Display(Name = "Editorial")]
        public int EditorialId { get; set; }
        public Editorial Editorial { get; set; }

        [Display(Name = "Date Release")]
        public DateTime DateReleased { get; set; }

        //Foreign Key for Science
        [Display(Name = "Science")]
        public int ScienceId { get; set; }
        public Science Science { get; set; }

        //Foreign Key for Language
        [Display(Name = "Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        [Display(Name= "Book Status")]
        public int BookId { get; set; }
        public BookStatus BookStatus { get; set; }



    }
}
