using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace Model
{
    public class Campaign : ICampaign
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }    
        public User User { get; set; }

        IUser ICampaign.User => User;

        public Campaign(DateTime dateCreated, int userId)
        {
            DateCreated= dateCreated;
            UserId= userId;
        }
    }
}
