using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace PRUEBA_TECNICA_IMOVS.Api.Configuration
{
    public static class JsonConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            config.Formatters.Clear();
            var json = new JsonMediaTypeFormatter();
            json.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            config.Formatters.Add(json);
        }
    }
}