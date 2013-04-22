using System;
using Nancy.Bootstrapper;
using Nancy.Routing;

namespace Nancy.CORS
{
    public class CORSStartup : IApplicationStartup
    {
        private readonly IRoutePatternMatcher _routePatternMatcher;

        public CORSStartup (IRoutePatternMatcher routePatternMatcher)
        {
            _routePatternMatcher = routePatternMatcher;
        }

        #region Implementation of IApplicationStartup

        public void Initialize(IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
            {
                if (string.Equals(ctx.Request.Method, "OPTIONS", StringComparison.InvariantCultureIgnoreCase))
                {
                    
                }
            });
        }

        #endregion
    }
}