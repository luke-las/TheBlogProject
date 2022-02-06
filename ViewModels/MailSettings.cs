using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProject.ViewModels
{
    public class MailSettings
    {
        //configure and use an SMTP server 
        //from e.g. google
        public string Mail { get; set; }
        public string Displayname { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

    }
}
