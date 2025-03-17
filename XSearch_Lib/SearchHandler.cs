using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using System.Security.Authentication;
using static System.Collections.Specialized.BitVector32;
using System.Reflection;
using System.Net;

namespace XSearch_Lib
{
    /// <summary>
    /// Shared data on the HttpClient instance used to query domains.
    /// </summary>
    public static class SearchHandler
    {
        // CONSTANTS

        public const int MAX_CONCURRENT_SEARCHES = 5;

        // PROPERTIES

        public static HttpClient SharedClient 
        { 
            get
            {
                if (_sharedClient == null)
                {
                    _sharedClient = InitializeClient();
                }
                return _sharedClient;
            }
            
        }

        private static HttpClient _sharedClient = new HttpClient();

        private static HttpClient InitializeClient()
        {

            _sharedClient = new HttpClient();
            _sharedClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36");
            _sharedClient.DefaultRequestHeaders.Add("Authorization", "Bearer 134134134");

            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            return _sharedClient;
        }

    }
}
