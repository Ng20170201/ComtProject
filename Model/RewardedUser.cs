using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace Model
{
    public class RewardedUser : IRewardedUser
    {
        public int UserId { get; set; }
        public string CostumerId { get; set; }
        public DateTime DateRewarded { get; set; }

        public bool PurchasedReward { get; set; }
        public User User { get; set; }


        public RewardedUser(int userId, string costumerId, DateTime dateRewarded)
        {
            UserId = userId;
            CostumerId = costumerId;
            DateRewarded = dateRewarded;
        }

        public RewardedUser(IRewardedUser rewardedUser)
        {
            UserId = rewardedUser.UserId;
            CostumerId = rewardedUser.CostumerId;
            DateRewarded = rewardedUser.DateRewarded;
            PurchasedReward = rewardedUser.PurchasedReward;
        }
    }
}
