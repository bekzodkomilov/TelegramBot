using System.Text.Json.Serialization;

namespace PrayerTime.DTO.TimingsByLL
{
    public class Meta
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("method")]
        public Method Method { get; set; }

        [JsonPropertyName("latitudeAdjustmentMethod")]
        public string LatitudeAdjustmentMethod { get; set; }

        [JsonPropertyName("midnightMode")]
        public string MidnightMode { get; set; }

        [JsonPropertyName("school")]
        public string School { get; set; }

        [JsonPropertyName("offset")]
        public Offset Offset { get; set; }
    }


}