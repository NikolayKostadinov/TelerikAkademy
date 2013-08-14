using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace SecretCommunicator.WebData.Library
{
    public class User
    {
        public Guid Id { get; set; }

        public List<string> ChannelName { get; set; }
    }
}
