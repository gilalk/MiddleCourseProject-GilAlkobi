using SchoolManagement.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DB
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        bool IsExist(string userName);
        Users Login(string userName, string password);
        Account GetAccount(int id);
    }
}
