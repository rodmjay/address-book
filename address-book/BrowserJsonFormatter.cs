#region

using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#endregion

namespace AddressBook
{
    public class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        public BrowserJsonFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "text/html", StringComparison.InvariantCultureIgnoreCase,
                true, "application/json"));
            SerializerSettings.Formatting = Formatting.Indented;
            SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}