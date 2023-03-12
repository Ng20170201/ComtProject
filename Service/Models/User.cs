using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace Service.Models
{
    public class User : IUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool StartedCampaign { get; set; }

        public ICampaign Campaign { get; set; }

        public int DailyAddedReward { get; set; }

        public string Password { get; set; }

        public List<IRewardedUser> RewardedUsers { get; set; }

        public User(int id, string name, string username, string password, bool startedCampaign, int dailyAddedReward, string email)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            DailyAddedReward = dailyAddedReward;
            StartedCampaign = startedCampaign;
            Email = email;
        }
    }
}
