using SchoolManagement.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DB
{
    public class SortById : IComparer<CrewMember>
    {
        public int Compare(CrewMember? x, CrewMember? y)
        {
            return(x.Id.CompareTo(y.Id));
        }
    }

    public class SortByFirstName : IComparer<CrewMember>
    {
        public int Compare(CrewMember? x, CrewMember? y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }

    public class SortByGender : IComparer<CrewMember>
    {
        public int Compare(CrewMember? x, CrewMember? y)
        {
            return x.Gender.CompareTo(y.Gender);
        }
    }


}
