using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer4.OAuth2.Config
{
    public class Resources
    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }
    }
}
