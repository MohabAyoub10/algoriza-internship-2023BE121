using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
    {
        Task<ApplicationUser> Find(string username, string password);
        Task<bool> CheckPassword(ApplicationUser user, string password);

        Task<string> GetRole(ApplicationUser user);
    }
}
