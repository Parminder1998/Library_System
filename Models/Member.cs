using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library_System.Models
{
    //Member record information.
    public class Member
    {
        //Member id.
        public int Id { get; set; }

        //Member name.
        public string MemberName { get; set; }

        //Contact number.
        public string ContactNumber { get; set; }

        //Member regsitration id.
        [NotMapped]
        public string MemberRegistrationId {
            get {

                return "LIB0000"+Id;
            }
        }



    }
}
