using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop
{
    [Serializable]
    public class UserLogin
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
    }
}