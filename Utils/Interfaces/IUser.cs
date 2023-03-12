using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Interfaces
{
    public interface IUser
    {
        public int Id { get; }
        public string Name { get; }
        public string Username { get; }
        public string Email { get; }
        public bool StartedCampaign { get; }

        public ICampaign Campaign { get; }

        public int DailyAddedReward { get; }

        public string Password { get; }

        public List<IRewardedUser> RewardedUsers { get; }
    }
}
