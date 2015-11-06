using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Proxy
{
    public class Proxy
    {
        //protected static readonly string _endPoint = "http://movieshopapi.azurewebsites.net/api/";
        protected static readonly string _endPoint = "http://localhost:21748/api/";

        public static string GetBaseString()
        {
            return _endPoint;
        }
    }
}
