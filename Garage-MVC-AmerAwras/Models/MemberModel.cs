using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{
    public class MemberModel
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }
        public string FullName { get; set; }


        public MemberModel(Member member)
        {
            MemberId = member.MemberId;
            FirstName = member.FirstName;
            LastName = member.LastName;
            PhoneNr = member.PhoneNr;
            FullName = member.FirstName +" " + member.LastName;

        }
           
    }
}