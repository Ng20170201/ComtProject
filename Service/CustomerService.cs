using System.Diagnostics;
using System.Transactions;
using Model;
using RepositoriesInterfaces;
using ServiceReference1;
using ServicesInterfaces;
using Utils.ErrorModels;
using Utils.Interfaces;

namespace Service
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository _customerRepo;
        public IUserService _userService;
        public IUserRepository _userRepo;
        public ICampaignRepository _campaignRepo;
        public SOAPDemoSoap _soapService;
        public CustomerService(SOAPDemoSoap soapService, ICampaignRepository campaignRepo, ICustomerRepository customerRepo, IUserService userService, IUserRepository userRepo)
        {
            _soapService = soapService;
            _campaignRepo = campaignRepo;
            _customerRepo = customerRepo;
            _userService = userService;
            _userRepo = userRepo;  
        }

        public async Task<bool> AddCustomerReward(string id)
        {

            Person customer = await _soapService.FindPersonAsync(id);

            if( customer == null)
            {
                throw new SoapServiceError("Customer with this id is not exixt");
            }

            var user = await _userService.GetUserWithRewardedUser();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    int idUser = await _userService.GetLoggedInUserId();
                    DateTime nowTime = DateTime.UtcNow;

                    bool startedCampaign = false;

                    if (user.StartedCampaign == false)
                    {
                        startedCampaign = true;
                        Campaign campaign = new Campaign(nowTime,idUser);
                        await _campaignRepo.AddCampaign(campaign);
                    }


                    await AddReward(user,new RewardedUser(idUser, id, nowTime));

                    User userChanged = new User(user.Id, user.Name, user.Username, user.Password, startedCampaign, user.DailyAddedReward + 1, user.Email);
                    await _userRepo.Update(userChanged);

                    scope.Complete();
                }

                catch (Exception ex)
                {
                    scope.Dispose();
                }
            }

           
            return true;
        }

        private async Task AddReward(IUser user,RewardedUser rewardedUser)
        {
            if (user.DailyAddedReward == 5)
            {
                throw new BadRequestError("You have already awarded 5 prizes");
            }
            if (user.RewardedUsers.Any(x => x.CostumerId == rewardedUser.CostumerId
            && (rewardedUser.DateRewarded.Subtract(x.DateRewarded).TotalHours <= 24))){

                throw new BadRequestError("You alredy added reward for this customer today");
            }

            await _customerRepo.AddCustomerReward(rewardedUser);

        }
    }
}