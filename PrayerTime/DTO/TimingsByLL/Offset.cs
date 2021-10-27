using System.Text.Json.Serialization;

namespace PrayerTime.DTO.TimingsByLL
{
    public class Offset
    {
        [JsonPropertyName("Imsak")]
        public int Imsak { get; set; }

        [JsonPropertyName("Fajr")]
        public int Fajr { get; set; }

        [JsonPropertyName("Sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("Dhuhr")]
        public int Dhuhr { get; set; }

        [JsonPropertyName("Asr")]
        public int Asr { get; set; }

        [JsonPropertyName("Maghrib")]
        public int Maghrib { get; set; }

        [JsonPropertyName("Sunset")]
        public int Sunset { get; set; }

        [JsonPropertyName("Isha")]
        public int Isha { get; set; }

        [JsonPropertyName("Midnight")]
        public int Midnight { get; set; }
    }


}