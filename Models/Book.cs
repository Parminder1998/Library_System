using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library_System.Models
{
    //Holds book inofrmation
    public class Book
    {

        //Book id primary key
        public int Id { get; set; }

        //Name of the bbook.
        public string BookName { get; set; }

        //Category of the book
        public BookCategory Category{get; set;}

        //Book registration id.
        [NotMapped]
        public string LibraryBookRegistrationId {

            get {

                return "BN0000" + Id;

            }
        }

    }


    //Category enum.

public enum BookCategory {

     FICTION, THRILLER, MYSTERY, MUSICAL,BIOGRAPHY
}
}
