using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_System.Models
{
    //Lending record information.
    public class LendingRecord
    {
        //Lendign record Id.
        public int Id { get; set; }

        //Member Id 
        public int MemberId { get; set; }

        //Book id 
        public int BookId { get; set; }

        //Book reference
        public Book Book { get; set; }

        //Member reference
        public Member Member { get; set; }

        //Return  date.
        [DataType(DataType.Date)]
        public DateTime ReturnByDate { get; set;  }



    }
}
