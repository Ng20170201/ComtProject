using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Utils.Interfaces;

namespace DTOs
{
    public class UserDto : IUser
    {
        public int Id { get ; set ; }
        public string Name { get ; set; }
        public string Username { get ; set ; }
        public string Password { get; set; }

        public bool StartedCampaign { get; set; }

        public int DailyAddedReward { get; set; }

        public string Email { get; set; }

        public List<IRewardedUser> RewardedUsers { get; set; }

        public Campaign Campaign { get; set; }

        ICampaign IUser.Campaign => Campaign;

        public UserDto(LoginDto user)
        {
            Username = user.Username;
            Password = user.Password;
        }

    }
}
