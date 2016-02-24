namespace NetPontoSec.Repository
{
    using System.Collections.Generic;
    using NetPontoSec.Models;

    public static class InMemoryDatabase
    {
        public static readonly List<NetPontoUser> NetPontoUsers = new List<NetPontoUser>();
        public static readonly List<Post> Posts = new List<Post>();
    }
}
