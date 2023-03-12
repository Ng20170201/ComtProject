using Model;
using Utils.Interfaces;

namespace RepositoriesInterfaces
{
    public interface ICustomerRepository
    {
        public Task<bool> AddCustomerReward(IRewardedUser rewardedUser);
        public Task<List<IRewardedUser>> FindUsedReward(int id);
    }
}