using System.Text.Json.Serialization;

namespace PrayerTime.DTO.TimingsByLL
{
    public class Data
    {
        [JsonPropertyName("timings")]
        public Timings Timings { get; set; }

        [JsonPropertyName("date")]
        public Date Date { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }


}