using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Utils.Interfaces;

namespace RepositoriesInterfaces
{
    public interface ICampaignRepository
    {
        public Task<bool> AddCampaign(ICampaign campaign);
        Task<List<ICampaign>> FindAllMonthCampaign(DateTime now);
        public Task<ICampaign> FindMonthCampaign(DateTime now, int userID);
    }
}
