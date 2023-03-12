using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Interfaces
{
    public interface ICampaign
    {
        public int Id { get; }
        public DateTime DateCreated { get;  }
        public int UserId { get; }

        public IUser User { get; }
    }
}
