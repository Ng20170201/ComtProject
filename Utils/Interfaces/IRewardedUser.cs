using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Interfaces
{
    public interface IRewardedUser
    {
        public int UserId { get; }
        public bool PurchasedReward { get; }

        public string CostumerId { get;  }
        public DateTime DateRewarded { get;  }
    }
}
