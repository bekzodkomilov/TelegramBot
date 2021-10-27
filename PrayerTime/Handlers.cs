using System.Reflection.Metadata;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PrayerTime.Services;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using PrayerTime.Entity;

namespace PrayerTime
{
    public class Handlers
    {
        private readonly ILogger<Handlers> _logger;
        private readonly IStorageService _storage;
        private readonly TimingsByLLService _timings;
        public Handlers(ILogger<Handlers> logger, IStorageService storage, TimingsByLLService timings)
        {
            _logger = logger;
            _storage = storage;
            _timings = timings;
        }

        public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken ctoken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException => $"Error occured with Telegram Client: {exception.Message}",
                _ => exception.Message
            };
            _logger.LogCritical(errorMessage);
            return Task.CompletedTask;
        }
        public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken ctoken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageRecieved(client, update.Message),
                UpdateType.EditedMessage => BotOnMessageEdited(client, update.EditedMessage),
                UpdateType.CallbackQuery => BotOnCallbackQueryReceived(client, update.CallbackQuery),
                UpdateType.InlineQuery => BotOnInlineQueryReceived(client, update.InlineQuery),
                UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(client, update.ChosenInlineResult),
                _ => UnknownUpdateHandlerAsync(client, update)
            };
            try
            {
                await handler;
            }
            catch(Exception e)
            {
                _logger.LogCritical(e.Message);
            }
        }

        private async Task UnknownUpdateHandlerAsync(ITelegramBotClient client, Update update)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnChosenInlineResultReceived(ITelegramBotClient client, ChosenInlineResult chosenInlineResult)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnInlineQueryReceived(ITelegramBotClient client, InlineQuery inlineQuery)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnCallbackQueryReceived(ITelegramBotClient client, CallbackQuery callbackQuery)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnMessageEdited(ITelegramBotClient client, Message editedMessage)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnMessageRecieved(ITelegramBotClient client, Message message)
        {
            if(!await _storage.ExistsAsync(message.Chat.Id))
            {
                var user = new BotUser(
                    chatId: message.Chat.Id,
                    username: message.From.Username,
                    fullname: $"{message.From.FirstName} {message.From.LastName}",
                    longitude: 0,
                    latitude: 0
                );
                var result = await _storage.InsertUserAsync(user);
                if(result.IsSuccess)
                {
                    _logger.LogInformation($"New user added: {user.ChatID} {user.Username} {user.Fullname}");
                }
            }
            else
            {
                _logger.LogInformation("User exists!");
            }
            if(message.Location != null)
            {
                await client.SendTextMessageAsync(
                    message.Chat.Id,
                    "Location successfully accepted",
                    replyToMessageId: message.MessageId,
                    replyMarkup: Buttons.MenuButtons()
                );
                var user = await _storage.GetUserAsync(message.Chat.Id);
                user.Longitude = message.Location.Longitude;
                user.Latitude = message.Location.Latitude;
                await _storage.UpdateUserAsync(user);
            }
            var _user = await _storage.GetUserAsync(message.Chat.Id);
            var a = message.Text switch
            {
                "/start"    => await client.SendTextMessageAsync(
                                message.Chat.Id,
                                "Botga xush kelibsiz! " + " " + message.Chat.FirstName,
                                ParseMode.Markdown,
                                replyMarkup: Buttons.GetLocationButton()),
                "Settings"  => await client.SendTextMessageAsync(
                                message.Chat.Id,
                                "Settings",
                                ParseMode.Markdown,
                                replyMarkup: Buttons.SettingsButtons()),
                "Today"     => await client.SendTextMessageAsync(
                                message.Chat.Id,
                                await _timings.getTodayTimings(_user.Longitude ,_user.Latitude),
                                ParseMode.Markdown,
                                replyMarkup: Buttons.MenuButtons()),
                "Back to menu" => await client.SendTextMessageAsync(
                                message.Chat.Id,
                                "Back to menu",
                                ParseMode.Markdown,
                                replyMarkup: Buttons.MenuButtons()),
                _           => await client.SendTextMessageAsync(
                                message.Chat.Id,
                                "Hozircha shu.",
                                ParseMode.Markdown)
            };
        }
    }
}