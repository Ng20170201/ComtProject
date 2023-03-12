using Microsoft.EntityFrameworkCore;
using Model;
using Model.DBCommunication;
using RepositoriesInterfaces;
using Utils.Interfaces;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public EntityContext _context;
        public CustomerRepository(EntityContext context) {
            _context = context;
        }

        public async Task<bool> AddCustomerReward(IRewardedUser rewardedUser)
        {
           await _context.RewardedUsers.AddAsync(new RewardedUser(rewardedUser));
            _context.SaveChanges();

            return true;
        }

        public async Task<List<IRewardedUser>> FindUsedReward(int id)
        {
            var result = await _context.RewardedUsers
                .Where(x => x.UserId == id && x.PurchasedReward)
                .ToListAsync<IRewardedUser>();

            return result;
        }
    }
}