using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DBCommunication;
using RepositoriesInterfaces;
using Utils.Interfaces;

namespace Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        public EntityContext _context;

        public CampaignRepository(EntityContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCampaign(Campaign campaign)
        {
            await _context.Campaigns.AddAsync(campaign);


            _context.SaveChanges();

            return true;
        }

        public async Task<List<ICampaign>> FindAllMonthCampaign(DateTime now)
        {
            var result = await _context.Campaigns
                .Where(x => (now - x.DateCreated).TotalDays >= 31)
                .Include(x=>x.User)
                .ToListAsync<ICampaign>();

            return result;
        }

        public async Task<ICampaign> FindMonthCampaign(DateTime now, int userID)
        {
            var result  = await _context.Campaigns
                .Where(x => (now-x.DateCreated).TotalDays >= 31 && userID==x.UserId) 
                .SingleOrDefaultAsync();

            return result;
        }
    }
}
