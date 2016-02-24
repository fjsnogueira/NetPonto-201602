using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetPontoSec.Authorization
{
    public static class NetPontoOpps
    {
        public static readonly OperationRequirement Create = new OperationRequirement { Name = "Create" };
        public static readonly OperationRequirement Read = new OperationRequirement { Name = "Read" };
        public static readonly OperationRequirement Edit = new OperationRequirement { Name = "Edit" };
        public static readonly OperationRequirement Delete = new OperationRequirement { Name = "Delete" };
    }
}
