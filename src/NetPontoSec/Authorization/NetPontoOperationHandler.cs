using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetPontoSec.Authorization
{
    using System.Security.Claims;

    using Microsoft.AspNet.Authorization;

    using NetPontoSec.Models;

    public class NetPontoOperationHandler : AuthorizationHandler<OperationRequirement, Post>
    {
        protected override void Handle(AuthorizationContext context, OperationRequirement requirement, Post resource)
        {
            if (requirement.Name.Equals("Edit"))
            {
                if (context.User.GetUserId().Equals(resource.AuthorId.ToString()))
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}
