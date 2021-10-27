using System.Text.Json.Serialization;

namespace PrayerTime.DTO.TimingsByLL
{
    public class Timings
    {
        [JsonPropertyName("Fajr")]
        public string Fajr { get; set; }

        [JsonPropertyName("Sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("Dhuhr")]
        public string Dhuhr { get; set; }

        [JsonPropertyName("Asr")]
        public string Asr { get; set; }

        [JsonPropertyName("Sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("Maghrib")]
        public string Maghrib { get; set; }

        [JsonPropertyName("Isha")]
        public string Isha { get; set; }

        [JsonPropertyName("Imsak")]
        public string Imsak { get; set; }

        [JsonPropertyName("Midnight")]
        public string Midnight { get; set; }
    }


}