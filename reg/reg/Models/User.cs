using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reg.Models
{
    public class User
    {
        public string email { get; set; }
        public string psw { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string idcard { get; set; }
        public string lineid { get; set; }
        public char status { get; set; }
        public DateTime ucreate { get; set; }
    }
}
