using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using GSF.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.EmailServices;
using ServicesInterfaces;

namespace Service.BackgroundServices
{
    public class CampaignBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public CampaignBackgroundService(IServiceScopeFactory serviceProvider)
        {
            _scopeFactory = serviceProvider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _campaignService = scope.ServiceProvider.GetRequiredService<ICampaignService>();
                    var _emailServiceCsv = scope.ServiceProvider.GetRequiredService<IEmailServiceCSV>();

                    await SendEmailCSV(_campaignService,_emailServiceCsv);



                    await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken); 
                }
            }
        }

        private async Task SendEmailCSV(ICampaignService _campaignService, IEmailServiceCSV emailServiceCSV)
        {
            var campaignMonth = await _campaignService.FindAllMonthCampaign();

            var users = campaignMonth.Select(x => x.User);

            foreach (var user in users)
            {
                var purchasedRewards = await _campaignService.GetPurchasedRewardsForUsers(user.Id);

                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = true,
                    Quote = '"',
                    Encoding = Encoding.UTF8
                };
                using (var writer = new StreamWriter($"purchased{user.Id}.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    //csv.WriteRecords(purchasedRewards);
                    //Attachment attachment = new Attachment("C:\\Users\\nikol\\OneDrive\\Radna površina\\Nikola algoritmi\\projects\\Comt\\Comt\\purchased1.csv", MediaTypeNames.Text.Plain);
                    //await emailServiceCSV.SendEmail("nikolag857@gmail.com", user.Email, "CSV"," ", attachment);
                    //File.Delete($"purchased{user.Id}.csv");
                }
            }
        }
    }
}
