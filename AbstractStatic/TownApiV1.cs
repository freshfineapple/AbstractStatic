using System;

namespace AbstractStatic
{
    // (Abstract base at bottom of the file)
    public class TownApiV1 : BaseServerApi_InSameFile
    {
        //---------------------------------------------------------------------
        // Option 1: Properties must be added; enforced by base's abstractness.
        //           Uris are non-static fields, must be built w/ constructor.
        //---------------------------------------------------------------------
        
        // By inheritance, compiler forces us to remember to implement these.
        // They are not static, even though they "should" be.
        protected override string Host => "http://www.host.com";
        protected override string ApiName => "town";
        protected override string Version => "1";
        
        // Not static, but "should" be.
        private Uri ApiCall1;
        private Uri ApiCall2;
        
        public TownApiV1()
        {
            // Definition separate from declaration, awkward.
            ApiCall1 = BuildApiUri("apiCall1");
            ApiCall2 = BuildApiUri("apiCall2");
            
            // Can't define at declaration above, because initialization
            // is a "static context" and BuildApiUri is non-static.
        }
        
        
        //---------------------------------------------------------------------
        // Option 2: Author must know to implement properties; can't be enforced.
        //           Uris are static, but the builder helper call is long.
        //---------------------------------------------------------------------
        
        // Properties are static, but the compiler didn't force us to add them.
        // Must rely on copy-paste and hope variable name pattern is continued.
        private static string Host_ => "http://www.host.com";
        private static string ApiName_ => "town";
        private static string Version_ => "1";

        // -----Option 2a -- Static Field-----
        // Uris are static, hooray.
        // Builder method call is long and must have every field. Convenience of builder is lessened.
        private static Uri ApiCall1_ = BuildApiUriStatic(Host_, ApiName_, Version_, "apiCall1");
        private static Uri ApiCall2_ = BuildApiUriStatic(Host_, ApiName_, Version_, "apiCall2");

        // -----Option 2b -- Nested Class-----
        public static class Uris
        {
            // Same tradeoffs as Option 2a.
            public static Uri ApiCall1_ = BuildApiUriStatic(Host_, ApiName_, Version_, "apiCall1");
            public static Uri ApiCall2_ = BuildApiUriStatic(Host_, ApiName_, Version_, "apiCall2");
        }
    }
    
    public abstract class BaseServerApi_InSameFile
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