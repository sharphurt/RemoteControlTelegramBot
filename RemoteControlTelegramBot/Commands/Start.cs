using Telegram.Bot;
using Message = Telegram.Bot.Types.Message;

namespace RemoteControlTelegramBot.Commands;

public class Start : BaseCommandHandler
{
    public override async Task HandleCommand(string command, ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        if (command == "/start")
        {
            await client.SendTextMessageAsync(message.Chat, "Привет! Доступные команды", cancellationToken: cancellationToken);
        }

        await base.HandleCommand(command, client, message, cancellationToken);
    }
}