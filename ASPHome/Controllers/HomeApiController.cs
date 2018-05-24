using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPHome.Controllers
{
    public class HomeApiController : ApiController
    {
        public string Get()
        {
            string date = DateTime.Now.ToShortDateString();
            return date;
        }
    }
}
