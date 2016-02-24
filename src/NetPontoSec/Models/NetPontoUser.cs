using System.Collections.Generic;

namespace NetPontoSec.Models
{
    public class NetPontoUser
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<KeyValuePair<string, string>> Claims { get; set; }
    }
}
