using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetPontoSec.Authorization
{
    using Microsoft.AspNet.Authorization;

    public class NoPehpeesHandler : AuthorizationHandler<NoPhpeesRequirement>
    {
        protected override void Handle(AuthorizationContext context, NoPhpeesRequirement requirement)
        {
            if (!context.User.Claims.Any(x => x.Type.Equals("Language") && x.Value.Equals("PHP")))
            {
                context.Succeed(requirement);  
            }
        }
    }
}
