using System.Text.Json.Serialization;

namespace PrayerTime.DTO.TimingsByLL
{
    public class Method
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("params")]
        public Params Params { get; set; }
    }


}