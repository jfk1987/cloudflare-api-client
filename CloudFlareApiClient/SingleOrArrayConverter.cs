using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudFlareApiClient
{
    public class SingleOrArrayZoneResultConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if(token.Type == JTokenType.Null)
            {
                return token.ToObject<T>();
            }

            if(token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }

            var result = new List<T> { token.ToObject<T>() };

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
