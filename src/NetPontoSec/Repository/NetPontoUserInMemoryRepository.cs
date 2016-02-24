namespace NetPontoSec.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    using NetPontoSec.Models;

    public class NetPontoUserInMemoryRepository : GenericRepository<NetPontoUser>, INetPontoUserRepository
    {
        public NetPontoUserInMemoryRepository()
            : base(InMemoryDatabase.NetPontoUsers)
        {
            lock (InMemoryDatabase.NetPontoUsers)
            {
                if (InMemoryDatabase.NetPontoUsers.Any())
                {
                    return;
                }


                this.Context.Add(
                    new NetPontoUser
                    {
                        UserId = 1,
                        Username = "Alice",
                        Password = "pass",
                        Claims =
                                new List<KeyValuePair<string, string>>
                                    {
                                        new KeyValuePair<string, string>(
                                            ClaimTypes.Role,
                                            "Author"),
                                        new KeyValuePair<string, string>(
                                            "Language",
                                            "C#"),
                                        new KeyValuePair<string, string>(
                                            "Language",
                                            "F#")
                                    }
                    });

                this.Context.Add(
                    new NetPontoUser
                    {
                        UserId = 2,
                        Username = "Bob",
                        Password = "pass",
                        Claims =
                                new List<KeyValuePair<string, string>>
                                    {
                                        new KeyValuePair<string, string>(
                                            ClaimTypes.Role,
                                            "Author"),
                                        new KeyValuePair<string, string>(
                                            "Language",
                                            "C#"),
                                        new KeyValuePair<string, string>(
                                            "Language",
                                            "Haskell")
                                    }
                    });

                this.Context.Add(
                    new NetPontoUser
                    {
                        UserId = 3,
                        Username = "Eve",
                        Password = "pass",
                        Claims =
                                new List<KeyValuePair<string, string>>
                                    {
                                        new KeyValuePair<string, string>(
                                            ClaimTypes.Role,
                                            "Reader"),
                                        new KeyValuePair<string, string>(
                                            "Language",
                                            "C#"),
                                        new KeyValuePair<string, string>(
                                            "Language",
                                            "PHP")
                                    }
                    });
            }
        }
    }
}
