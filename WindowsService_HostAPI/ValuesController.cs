using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WindowsService_HostAPI
{
    public class ValuesController : ApiController
    {
        public String GetString(Int32 id)
        {
            return "This is string returned through the Windows service.";
        }

        [HttpPost()]
        public JObject FileInfo([FromBody] Models.File data)
        {
            JObject jObject = JObject.Parse(JsonConvert.SerializeObject(data));
            var filename = string.Format("{0}{1}.{2}", @"C:\FactorPOC\Data\data_", DateTime.Now.ToString("MMddyyyymmss"), "json");
            System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(data));
            // serialize JSON directly to a file
            using (StreamWriter file = System.IO.File.CreateText(@filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
            return jObject;
        }

        [HttpPost()]
        public JObject TrackingNumber([FromBody] Models.TrackingNumber data)
        {
            JObject jObject = JObject.Parse(JsonConvert.SerializeObject(data));
            var filename = string.Format("{0}{1}.{2}",
                @"C:\FactorPOC\Data\data_", DateTime.Now.ToString("MMddyyyymmss"), "json");
            System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(data));
            // serialize JSON directly to a file
            using (StreamWriter file = System.IO.File.CreateText(@filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
            return jObject;
        }
    }
}