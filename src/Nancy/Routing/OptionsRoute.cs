namespace Nancy.Routing
{

    using System;
    using System.Collections.Generic;

    using Nancy.Routing.CORS;

    /// <summary>
    /// Route that is returned when the path could be matched but, the method was OPTIONS and there was no user defined handler for OPTIONS.
    /// </summary>
    public class OptionsRoute : Route
    {
        public OptionsRoute(string path, IEnumerable<string> allowedMethods)
            : base("OPTIONS", path, null, x => CreateMethodOptionsResponse(allowedMethods))
        {
        }

        public OptionsRoute (string path, IEnumerable<string> allowedMethods, IEnumerable<string> corsAllowedMethods, IEnumerable<CORSOptions> corsOptions)
            : base("OPTIONS", path, null, x => CreateMethodOptionsResponse(allowedMethods, corsAllowedMethods, corsOptions))
        {            
        }
        
        private static Response CreateMethodOptionsResponse(IEnumerable<string> allowedMethods)
        {
            var response = new Response();
            response.Headers["Allow"] = string.Join(", ", allowedMethods);

            response.StatusCode = HttpStatusCode.OK;

            return response;
        }

        private static Response CreateMethodOptionsResponse (IEnumerable<string> allowedMethods, IEnumerable<string> corsAllowedMethods, IEnumerable<CORSOptions> corsOptions)
        {
            var response = CreateMethodOptionsResponse(allowedMethods);
            
            var options = CORSOptions.MergeCORSOptions(corsOptions);
            
            // if (options != null) ctx.ModifyResponseForCORS(corsAllowedMethods, options, response);

            return response;
        }
    }
}