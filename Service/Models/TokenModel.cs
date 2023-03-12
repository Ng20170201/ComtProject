using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Interfaces;

namespace Service.Models
{
    public class TokenModel : ITokenModel
    {
        public string Token { get; set; }
    }
}
