using System;
using System.Collections.Generic;

namespace AbstractStatic
{
    public abstract class BaseServerApi
    {
        protected abstract string Host { get; }
        protected abstract string ApiName { get; }
        protected abstract string Version { get; }

        protected Uri BuildApiUri(string method)
        {
            return new Uri($"{Host}/{ApiName}/{Version}/{method}");
        }
        
        protected static Uri BuildApiUriStatic(string host, string apiName, string version, string method)
        {
            return new Uri($"{host}/{apiName}/{version}/{method}");
        }
    }
}