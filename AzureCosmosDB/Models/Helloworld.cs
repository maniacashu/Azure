using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureCosmosDB.Models
{
    public class Helloworld
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }
    }
}