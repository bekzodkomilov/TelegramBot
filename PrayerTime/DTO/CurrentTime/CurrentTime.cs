using System.Text.Json.Serialization;

namespace PrayerTime.DTO.CurrentTime
{
    public class Root
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }
    }


}