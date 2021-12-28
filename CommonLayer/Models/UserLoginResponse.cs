using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class UserLoginResponse
    {
        public long Id
        {
            get; set;
        }
        public string token { get; set; }
    }

}
