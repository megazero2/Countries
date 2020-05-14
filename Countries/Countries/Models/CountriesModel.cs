using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Countries.Models
{
    public partial class Datum
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alpha2")]
        public string Alpha2 { get; set; }

        [JsonProperty("alpha3")]
        public string Alpha3 { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("iso_3166_2")]
        public string Iso3166_2 { get; set; }

        [JsonProperty("is_independent")]
        public bool IsIndependent { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public partial class Datum
    {
        public static Datum FromJson(string json) => JsonConvert.DeserializeObject<Datum>(json, Countries.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Datum self) => JsonConvert.SerializeObject(self, Countries.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
