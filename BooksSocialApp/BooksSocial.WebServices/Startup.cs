﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using System.Net.Http;
using System.Web.Http;
using Owin;

[assembly: OwinStartup(typeof(BooksSocial.WebServices.Startup))]

namespace BooksSocial.WebServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            
        }
    }
}
