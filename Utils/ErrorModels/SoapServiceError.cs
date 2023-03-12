using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ErrorModels
{
    public class SoapServiceError  : Exception
    {
        public SoapServiceError(string message) : base(message)
        {
        }
    }
}
