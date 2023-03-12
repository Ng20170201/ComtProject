using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using RepositoriesInterfaces;
using Service.Models;
using ServiceReference1;
using ServicesInterfaces;
using Utils.Interfaces;

namespace Service
{
    public class CampaignService : ICampaignService
    {
        public IUserService _userService;
        public ICustomerRepository _customerRepo;
        public ICampaignRepository _campaignRepo;
        public SOAPDemoSoap _soapDemo;
        public CampaignService(SOAPDemoSoap soapDemo, ICampaignRepository campaignRepo, IUserService userService, ICustomerRepository customerRepo) {

            _customerRepo = customerRepo;
            _userService = userService;
            _campaignRepo= campaignRepo;
            _soapDemo = soapDemo;
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

        public async Task<List<ICsvModel>> GetPurchasedRewards()
        {
            var userID = await _userService.GetLoggedInUserId();

            var campaign = await FindPurchasedRewards(userID);

            var usedRewards = await _customerRepo.FindUsedReward(userID);

            List<CSVModel> csvData= new List<CSVModel>();

            foreach (var item in usedRewards)
            {
                var person = await _soapDemo.FindPersonAsync(item.CostumerId);
                csvData.Add(new CSVModel(person.Name,person.SSN,item.DateRewarded,person.Age));
            }

            return csvData.ToList<ICsvModel>();
        }

        public async Task<List<IRewardedUser>> GetPurchasedRewardsForUsers(int id)
        {
            var usedRewards = await _customerRepo.FindUsedReward(id);

            return usedRewards;
        }
    }
}
