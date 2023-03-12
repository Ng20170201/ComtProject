using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ErrorModels
{
    public class BadRequestError : Exception
    {
        public BadRequestError(string message) : base(message)
        {
        }
    }
}
