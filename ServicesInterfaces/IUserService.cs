using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace ServicesInterfaces
{
    public interface IUserService
    {
        public Task<IUser> GetLoggedInUser();
        public Task<int> GetLoggedInUserId();
        public Task<IUser> GetUserWithRewardedUser();
        public Task<ITokenModel> Login(IUser userDto);
        public Task<bool> ResetNumberOfRewardForLoggedUser();
    }
}
