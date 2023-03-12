using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Interfaces
{
    public interface ICsvModel
    {
        public string NameField { get; }

        public string sSNField { get; }

        public long ageField { get; }

        public DateTime DateRewarded { get; }

    }
}
