using System.Text.Json.Serialization;

namespace PrayerTime.DTO.TimingsByLL
{
    public class Date
    {
        [JsonPropertyName("readable")]
        public string Readable { get; set; }

        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }

        [JsonPropertyName("gregorian")]
        public Gregorian Gregorian { get; set; }

        [JsonPropertyName("hijri")]
        public Hijri Hijri { get; set; }
    }


}