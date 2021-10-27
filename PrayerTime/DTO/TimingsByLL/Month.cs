using System.Text.Json.Serialization;

namespace PrayerTime.DTO.TimingsByLL
{
    public class Month
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("en")]
        public string En { get; set; }

        [JsonPropertyName("ar")]
        public string Ar { get; set; }
    }


}