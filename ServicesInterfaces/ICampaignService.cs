using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace ServicesInterfaces
{
    public interface ICampaignService
    {
        public Task<List<ICampaign>> FindAllMonthCampaign();
        public Task<ICampaign> FindPurchasedRewards(int userID);
        public Task<List<ICsvModel>> GetPurchasedRewards();
        public Task<List<IRewardedUser>> GetPurchasedRewardsForUsers(int id);
    }
}
