using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Tedon.Web.Common
{
    [Authorize]
    public class BaseController : Controller
    {
        protected IConfigurationRoot Config { get; private set; }

        public BaseController()
        {
            Config = Startup.Configuration;
        }
    }
}