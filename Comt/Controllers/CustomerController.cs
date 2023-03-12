using System.Formats.Asn1;
using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using ServiceReference1;
using ServicesInterfaces;
using Utils.Interfaces;

namespace Comt.Controllers
{
    [ApiController]
    [Route("CustomerController")]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerService;
        public ICampaignService _campaignService;
        public CustomerController(ICustomerService customerService, ICampaignService campaignService)
        {
            _customerService = customerService;
            _campaignService = campaignService;
        }

        [HttpPost]
        [Authorize]
        public async Task<bool> AddCustomerReward(string id)
        {
            await _customerService.AddCustomerReward(id);
            return true;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPurchasedReward()
        {

               
            var purchasedRewards = await _campaignService.GetPurchasedRewards();
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
                Quote = '"',
                Encoding = Encoding.UTF8
            };
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, csvConfig))
            {
                csv.WriteRecords(purchasedRewards);
                writer.Flush();
                stream.Position = 0;

                var fileContent = stream.ToArray();
                return File(fileContent, "text/csv", "customers.csv");
            }
        }
    }
}