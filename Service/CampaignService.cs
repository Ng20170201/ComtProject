using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using RepositoriesInterfaces;
using ServicesInterfaces;
using Utils.Interfaces;

namespace Service
{
    public class CampaignService : ICampaignService
    {
        public IUserService _userService;
        public ICustomerRepository _customerRepo;
        public ICampaignRepository _campaignRepo;
        public CampaignService(ICampaignRepository campaignRepo, IUserService userService, ICustomerRepository customerRepo) {

            _customerRepo = customerRepo;
            _userService = userService;
            _campaignRepo= campaignRepo;
        }

        public async Task<List<ICampaign>> FindAllMonthCampaign()
        {
            var nowTime = DateTime.UtcNow;
            var result = await _campaignRepo.FindAllMonthCampaign(nowTime);

            return result;
        }

        public async Task<ICampaign> FindPurchasedRewards(int userID)
        {
            var nowTime = DateTime.UtcNow;
            var campaign = await _campaignRepo.FindMonthCampaign(nowTime,userID);

            return campaign;
        }

        public async Task<List<IRewardedUser>> GetPurchasedRewards()
        {
            var userID = await _userService.GetLoggedInUserId();

            var campaign = await FindPurchasedRewards(userID);

            var usedRewards = await _customerRepo.FindUsedReward(campaign.Id);


            return usedRewards;
        }

        public async Task<List<IRewardedUser>> GetPurchasedRewardsForUsers(int id)
        {
            var usedRewards = await _customerRepo.FindUsedReward(id);

            return usedRewards;
        }
    }
}
