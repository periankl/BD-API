using Newtonsoft.Json;
using SheduleHubAPI.Contracts.Student;
using SheduleHubAPI.Contracts.StudentGroup;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using System;
using System.Text.RegularExpressions;

namespace BotClient
{
    internal class Program
    {
        private static string selectedGroupId;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting bot");

            var botClient = new TelegramBotClient("6766935920:AAHisLG9yxuvpUrkwf2-XMRcqcSxyj_Bss0");

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

            /*
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:7046/api/Student");

            Console.WriteLine(result);

            var test = await result.Content.ReadAsStringAsync();
            Console.WriteLine(test);


            GetStudentResponse[] studentResponses = JsonConvert.DeserializeObject<GetStudentResponse[]>(test);

            foreach (var studentResponse in studentResponses)
            {
                Console.WriteLine(studentResponse.IdStudent + " " + studentResponse.NameFirst + " " + studentResponse.Surname);
            }

            */

            Console.WriteLine($"{me} is working");

            Console.ReadLine();

            cts.Cancel();
        }

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            /*
                if (update.Message is not { } message)
                    return;
                if (message.Text is not { } messageText)
                    return;
             */

            if (update.Type == UpdateType.Message)
            {

                var message = update.Message;
                var messageText = message.Text;

                var chatId = message.Chat.Id;

                Console.WriteLine($"Recieved a '{messageText}' message in chat {chatId}.");

                if (message.Text == "Проверка")
                {
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Проверка: OK!",
                        cancellationToken: cancellationToken);
                }

                if (message.Text == "Привет")
                {
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Здраствуй, " + message.From.Username,
                        cancellationToken: cancellationToken);
                }

                if (message.Text == "Спасибо")
                {
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Всегда рад помочь, " + message.From.Username,
                        cancellationToken: cancellationToken);
                }

                if (message.Text == "Картинка")
                {
                    await botClient.SendPhotoAsync(
                        chatId: chatId,
                        photo: new InputOnlineFile(new Uri("https://ih1.redbubble.net/image.2626187403.2076/bg,f8f8f8-flat,750x,075,f-pad,750x1000,f8f8f8.jpg")),
                        caption: "Your fumo is here",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                }

                string stickerId = "CAACAgIAAxkBAAEC_5ZlrjDQV18QL21ew2Cv_1ct_mHSZAAChQ8AAnfsmUotw3Rw-ixLCzQE";
                if (message.Text == "Стикер")
                {
                    await botClient.SendStickerAsync(
                        chatId: chatId,
                        sticker: stickerId);
                }

                if (message.Text == "Видео")
                {
                    await botClient.SendVideoAsync(
                        chatId: chatId,
                        video: new InputOnlineFile(new Uri("https://rr2---sn-4g5lznez.googlevideo.com/videoplayback?expire=1705938619&ei=WzquZZKFKOy06dsPkbuFgAo&ip=84.239.42.13&id=o-AOvANX7xKGFmuaRx_BLttFA7k3N2gseb2tZDaoTzSEIq&itag=22&source=youtube&requiressl=yes&xpc=EgVo2aDSNQ%3D%3D&mh=T2&mm=31%2C29&mn=sn-4g5lznez%2Csn-4g5edndz&ms=au%2Crdu&mv=m&mvi=2&pl=24&initcwndbps=842500&spc=UWF9f8W51FyHVXbsOI9PBkFNdY_kK7poYGEe&vprv=1&svpuc=1&mime=video%2Fmp4&cnr=14&ratebypass=yes&dur=37.151&lmt=1696426088376788&mt=1705916699&fvip=1&fexp=24007246&c=ANDROID&txp=5318224&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cxpc%2Cspc%2Cvprv%2Csvpuc%2Cmime%2Ccnr%2Cratebypass%2Cdur%2Clmt&sig=AJfQdSswRAIgH_ADr3amRYB1_dLNQp-tdXQpBcbL385zxWaMDL_clvMCIF9pRz5HhUH9R2N4mw6oSFOFeqgdOHpeQg0P1gFPdTuT&lsparams=mh%2Cmm%2Cmn%2Cms%2Cmv%2Cmvi%2Cpl%2Cinitcwndbps&lsig=AAO5W4owRAIgKexCPfVT-CRXuCRaQwGosC8RO64Yt7-AcXpUCvC0klYCIC0VtpDZ9diaMKfQQSsnWKdZRCJYUiY1BWkOokYJgFIG&title=Gains%20of%20the%20void"))
                        );
                }

                if (message.Text == "Кнопка")
                {
                    InlineKeyboardMarkup inlineKeyboard = new(new[]
                    {
                    InlineKeyboardButton.WithUrl(
                        text: "Ссылка на SheduleHub",
                        url: "https://megami94.github.io/shedulehub.github.io/")
                });

                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Вот ваша кнопка с ссылкой",
                        replyMarkup: inlineKeyboard,
                        cancellationToken: cancellationToken);
                }


                if (message.Text == "/group")
                {
                    HttpClient client = new HttpClient();
                    var groupLink = await client.GetAsync("https://localhost:7046/api/StudentGroup");
                    var groupFilter = await groupLink.Content.ReadAsStringAsync();

                    GetStudentGroupResponse[] groups = JsonConvert.DeserializeObject<GetStudentGroupResponse[]>(groupFilter);
                    InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(
                        groups.Select(group => new[]
                        {
                        InlineKeyboardButton.WithCallbackData(text: group.NameGroup, callbackData: "group_" + group.IdGroup.ToString()),
                        })
                    );

                    await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Список всех групп",
                    replyMarkup: inlineKeyboard,
                    cancellationToken: cancellationToken);
                }
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {

                var callback = update.CallbackQuery;
                var chatId = update.CallbackQuery.From.Id;

                if (callback.Data.StartsWith("group_"))
                {
                    string groupId = callback.Data.Substring("group_".Length);
                    selectedGroupId = groupId;

                    Console.WriteLine($"Button {update.CallbackQuery.Data} was pressed in chat: {chatId}");

                    HttpClient client = new HttpClient();
                    var studentLink = await client.GetAsync("https://localhost:7046/api/Student");
                    var studentFilter = await studentLink.Content.ReadAsStringAsync();

                    GetStudentResponse[] students = JsonConvert.DeserializeObject<GetStudentResponse[]>(studentFilter);
                    var filteredStudents = students.Where(s => s.IdGroup.ToString() == groupId).ToArray();

                    InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(
                        filteredStudents.Select(student => new[]
                        {
                        InlineKeyboardButton.WithCallbackData(text: $"{student.NameFirst} {student.Surname}", callbackData: "student_" + student.IdStudent.ToString()),
                        })
                    );

                    await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Список всех студентов выбранной группы",
                    replyMarkup: inlineKeyboard,
                    cancellationToken: cancellationToken);

                    update.CallbackQuery = null;
                }

                else if (callback.Data.StartsWith("student_"))
                {
                    string studentId = callback.Data.Substring("student_".Length);
                    string groupId = selectedGroupId.ToString();

                    Console.WriteLine($"Button {update.CallbackQuery.Data} was pressed in chat: {chatId}");

                    HttpClient client = new HttpClient();
                    var studentLink = await client.GetAsync("https://localhost:7046/api/Student");
                    var studentFilter = await studentLink.Content.ReadAsStringAsync();

                    GetStudentResponse[] students = JsonConvert.DeserializeObject<GetStudentResponse[]>(studentFilter);
                    var filteredStudents = students.Where(s => s.IdStudent.ToString() == studentId).ToArray();

                    GetStudentResponse? student = new GetStudentResponse();
                    foreach (var i in filteredStudents)
                    {
                        student = i;
                    }

                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"ID: {student.IdStudent}\nEmail: {student.Email}\nИмя: {student.NameFirst}\nФамилия: {student.Surname}\nОтчество: {student.Patronymic}\nДата рождения: {student.BirthDate}\nID роли: {student.IdRole}",
                        cancellationToken: cancellationToken);
                }
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
