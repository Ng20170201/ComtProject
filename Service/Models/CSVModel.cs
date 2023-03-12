using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace Service.Models
{
    public class CSVModel : ICsvModel
    {
        public string NameField { get; set; }

        public string sSNField { get; set; }

        public DateTime DateRewarded { get; set; }

        public long ageField { get; set; }

        public CSVModel(string nameField,string ssnField, DateTime dateRewarded, long age)
        {
            NameField = nameField;
            sSNField=ssnField;
            DateRewarded = dateRewarded;
            ageField = age;

        }
    }
}
