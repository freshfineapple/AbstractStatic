using System;
using System.Collections.Generic;

namespace AbstractStatic
{
    public abstract class AbstractServerApi
    {
        public abstract string ApiName { get; }
        public abstract string Version { get; }

        public Uri BuildApiPathUri(string method)
        {
            return new Uri($"{ApiName}/{Version}/{method}");
        }
        
        private static Dictionary<string, Uri> _apiUriCache = new Dictionary<string, Uri>();  
    }
}