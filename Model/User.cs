using Utils.Interfaces;

namespace Model
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Username { get; set; }
        public string Email { get; set; }

        public int DailyAddedReward { get; set; }

        public bool StartedCampaign { get; set; }

        public string Password { get; set; }

        public Campaign Campaign { get; set; }


        public List<RewardedUser> RewardedUsers { get; set; }

        List<IRewardedUser> IUser.RewardedUsers => RewardedUsers.ToList<IRewardedUser>();

        ICampaign IUser.Campaign => Campaign;

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