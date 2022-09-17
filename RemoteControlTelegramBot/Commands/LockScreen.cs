using Telegram.Bot;
using Message = Telegram.Bot.Types.Message;

namespace RemoteControlTelegramBot.Commands;

public class LockScreen : BaseCommandHandler
{
    public override async Task HandleCommand(string command, ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        if (command == "/lock")
        {
            await client.SendTextMessageAsync(message.Chat, "Заблокировано", cancellationToken: cancellationToken);
        }
        
        await base.HandleCommand(command, client, message, cancellationToken);
    }
}