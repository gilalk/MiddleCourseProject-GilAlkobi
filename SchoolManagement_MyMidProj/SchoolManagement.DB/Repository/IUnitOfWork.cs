using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DB
{
    public interface IUnitOfWork : IDisposable
    {
        IManagerRepository Managers { get; }
        ICrewMemberRepository Teachers { get; }
        IAccountRepository Account { get; }
        int Complete();
    }
}
