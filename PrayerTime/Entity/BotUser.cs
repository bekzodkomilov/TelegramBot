using System.ComponentModel.DataAnnotations;
using System;

namespace PrayerTime.Entity
{
    public class BotUser
    {
        [Key]
        public long ChatID {get; set;}
        public string Username {get; set;}
        public string Fullname {get; set;}
        public float Longitude {get; set;}
        public float Latitude {get; set;}
        
        [Obsolete("Used only for Entity binding!")]
        public BotUser() {}

        public BotUser(long chatId, string username, string fullname, float longitude, float latitude)
        {
            ChatID = chatId;
            Username = username;
            Fullname = fullname;
            Longitude = longitude;
            Latitude = latitude;
        }
        
    }
}