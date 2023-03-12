using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.DBCommunication;
using RepositoriesInterfaces;
using Utils.Interfaces;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public EntityContext _context;
        public UserRepository( EntityContext context) {

            _context = context;

        }

        public async Task<IUser> GetUser(int id)
        {

            var user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task<IUser> GetUserWithRewardedUser(int id)
        {

            var user = await _context.Users.Where(x => x.Id == id)
                                                 .Include(x => x.RewardedUsers)
                                                 .SingleOrDefaultAsync();

            return user;
        }

        public async Task<IUser> Login(IUser model)
        {
            var user = await _context.Users
                                    .Where(x => x.Username == model.Username && x.Password == model.Password)
                                    .SingleOrDefaultAsync();

            return user;
        }

        public async Task<bool> Update(IUser user)
        {
            var newUser = await _context.Users.FindAsync(user.Id);

            newUser.Username=user.Username;
            newUser.Password=user.Password;
            newUser.Name = user.Name;
            newUser.StartedCampaign=user.StartedCampaign;
            newUser.DailyAddedReward = user.DailyAddedReward;

            _context.SaveChanges();

            return true;
        }
    }
}
