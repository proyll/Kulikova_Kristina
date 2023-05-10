using Domain.Models;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:7110/api/User");

            Console.WriteLine(result);

            var test = await result.Content.ReadAsStringAsync();
            Console.WriteLine(test);

            //Product[] products = JsonConvert.DeserializeObject<Product[]>(test); 

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductId + " " + product.NameP + " " + product.Price);
            //}

            Console.WriteLine("Hello, World!");

            var botClient = new TelegramBotClient("6284618332:AAFDm9yWE6mduIp5oczgA0LY5AMIPK6IePk");

            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
                );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Приветствую, @{me.Username}");
            Console.ReadLine();

            cts.Cancel();



        }

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
            {
                return;
            }
            if (message.Text is not { } messageText)
            {
                return;
            }

            var chatId = message.Chat.Id;

            Console.WriteLine($"Здравствуйте'{chatId}', {messageText}.");

            //Message sentMessage = await botClient.SendTextMessageAsync(
            //    chatId: chatId,
            //    text: "You said:\n" + messageText,
            //    cancellationToken: cancellationToken);

            if (message.Text == "Привет") //привествие
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Здравствуйте {message.Chat.Username}",
                    cancellationToken: cancellationToken); 
            }
            if (message.Text == "Мяу") //фото
            {
                await botClient.SendPhotoAsync(
                     chatId: chatId,
                     photo: "https://ru.pinterest.com/pin/118219558959816741/",
                     caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                     parseMode: ParseMode.Html,
                     cancellationToken: cancellationToken);
            }
            if (message.Text == "Ничего себе") //видео
            {
               await botClient.SendVideoAsync(
                        chatId: chatId,
                        video: "https://rr1---sn-4g5edndy.googlevideo.com/videoplayback?expire=1683293079&ei=N69UZMebGYGHyQW2yZnoDA&ip=188.126.89.90&id=o-AL2RmVD2qsxyaXO6KHnjc3oVD6BxTi72OC0c823fAa6_&itag=18&source=youtube&requiressl=yes&spc=qEK7B-OkngSFi0QnP-wrq9OYkLySYuJmxzTrZKMK4A&vprv=1&svpuc=1&mime=video%2Fmp4&ns=n5EVKbacqaPlLVKBqmg0AhgN&cnr=14&ratebypass=yes&dur=15.069&lmt=1673229726291244&fexp=24007246&c=WEB&txp=6219224&n=BXdAvV-Kk-vZ9w&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cspc%2Cvprv%2Csvpuc%2Cmime%2Cns%2Ccnr%2Cratebypass%2Cdur%2Clmt&sig=AOq0QJ8wRQIhAKKaSEasZqBmU8mhM4oLDJqQuqKkPVGUUqXbRAvgsrq4AiBTw0h1D6IbzetDWAdRGq11ntP6lxfg8gdh06VHsIftGw%3D%3D&redirect_counter=1&cm2rm=sn-5gose7s&req_id=ac348ac2eb20a3ee&cms_redirect=yes&cmsv=e&mh=au&mip=94.29.124.119&mm=34&mn=sn-4g5edndy&ms=ltu&mt=1683270856&mv=u&mvi=1&pl=18&lsparams=mh,mip,mm,mn,ms,mv,mvi,pl&lsig=AG3C_xAwRAIgEf0VqKZ6hK27bTMIVTa0z1etU9IWpPFzTcTdLKnXR6YCIEw57F3b3fkmOhhBZBvm1WzKsh82MljJzdI-5G2OtGz5",
                        thumb: "https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg",
                        supportsStreaming: true,
                        cancellationToken: cancellationToken);  
            }
            if (message.Text == "Спасибо" ) //стикер
            {
                Message message1 = await botClient.SendStickerAsync(
                    chatId: chatId,
                    sticker: "CAACAgIAAxkBAAEgq8lkVLaE18ZSQdkkVdbWTqoXL_rOxQACkhIAAnjJ0UuWbGnXnkR1OC8E",
                    cancellationToken: cancellationToken);
            }
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()

            };
            
            Console.WriteLine(ErrorMessage);

            return Task.CompletedTask;
        }
    }
}