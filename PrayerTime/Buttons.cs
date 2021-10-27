using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace PrayerTime
{
    public class Buttons
    {
        public static IReplyMarkup GetLocationButton()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Share my location", RequestLocation = true}},
                    new List<KeyboardButton>{ new KeyboardButton {Text = "Cancel"}}
                }
            };
        }
        public static IReplyMarkup MenuButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Today"}, new KeyboardButton {Text = "Tomorrow"}},
                    new List<KeyboardButton>{ new KeyboardButton {Text = "Next prayer time"}, new KeyboardButton {Text = "Settings"}}
                },
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup SettingsButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Reset location", RequestLocation = true }, new KeyboardButton {Text = "Turn on notifications"}},
                    new List<KeyboardButton>{ new KeyboardButton {Text = "Change language"}, new KeyboardButton {Text = "Back to menu"}}
                },
                ResizeKeyboard = true
            };
        }
    }
}