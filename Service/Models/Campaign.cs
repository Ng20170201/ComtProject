using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace Service.Models
{
    public class Campaign : ICampaign
    {
        public int Id {get;set;}

        public DateTime DateCreated { get; set; }

        public int UserId { get; set; }

        public IUser User { get; set; }

        public Campaign(DateTime dateCreated, int userId)
        {
            UserId = userId;
            DateCreated = dateCreated;
        }
    }
}
