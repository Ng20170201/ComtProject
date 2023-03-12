using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace RepositoriesInterfaces
{
    public interface IUserRepository
    {
        public Task<IUser> GetUserWithRewardedUser(int id);
        public Task<IUser> Login(IUser model);
        public Task<IUser> GetUser(int id);
        public Task<bool> Update(IUser user);
         
    }
}
