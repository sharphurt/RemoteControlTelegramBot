using RemoteControlTelegramBot.Commands;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace RemoteControlTelegramBot;

public class Bot
{
    private const string _tokenPath = @"C:\Users\sharphurt\remotecontrol_bot_token.txt";

    private static readonly ITelegramBotClient _botClient = new TelegramBotClient(File.ReadAllText(_tokenPath));

    private static readonly ICommandHandler _commandHandlerChain = new Start
    {
        NextHandler = new LockScreen()
    };

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
        {
            var message = update.Message;
            await _commandHandlerChain.HandleCommand(message?.Text?.ToLower()!, botClient, message!, cancellationToken);
        }
    }

    private static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
        // TODO
    }

    public void Run()
    {
        Console.WriteLine("Запущен бот " + _botClient.GetMeAsync().Result.FirstName);

        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        var receiverOptions = new ReceiverOptions();
        _botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);
        Console.ReadLine();
    }
}