using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoDatabaseAPI
{
    public class ValuesController : ApiController
    {
        [BasicAuthentication]
        public string Get()
        {
            return "WebAPI Method Called";
        }


    }
    
}