using System.Text.Json.Serialization;

namespace PrayerTime.DTO.TimingsByLL
{
    public class TimingsByLL
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }
}