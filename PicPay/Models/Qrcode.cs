using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeSpace.Application.PicPay.Models
{
    public class Qrcode
    {
        [JsonProperty("content", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("base64", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Base64 { get; set; }
    }
}
