using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetPontoSec.Authorization
{
    using Microsoft.AspNet.Authorization;

    public class OperationRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }
    }

}
