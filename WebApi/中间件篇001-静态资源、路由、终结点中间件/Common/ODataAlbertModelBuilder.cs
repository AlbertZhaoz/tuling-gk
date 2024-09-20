using Microsoft.AspNetCore.Identity;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using NET_FiveMinutes_008_UseIdentity.Models;

namespace NET_FiveMinutes_008_UseIdentity.Common
{
    public static class ODataAlbertModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Role>("Role");
            odataBuilder.EntitySet<User>("User");

            return odataBuilder.GetEdmModel();
        }
    }
}
