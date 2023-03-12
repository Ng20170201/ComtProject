using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Utils.Interfaces;

namespace Service.Models
{
    public class RewardedUser : IRewardedUser
    {
        public int UserId {get;set;}


        public bool PurchasedReward { get; set; }

        public string CostumerId { get; set; }

        public DateTime DateRewarded { get; set; }

        public RewardedUser(int userId, string customerId, DateTime dateRewarded)
        {
            UserId = userId;
            CostumerId = customerId;
            DateRewarded = dateRewarded;
        }
    }
}
