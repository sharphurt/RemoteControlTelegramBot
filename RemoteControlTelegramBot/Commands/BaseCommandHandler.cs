using Telegram.Bot;
using Message = Telegram.Bot.Types.Message;

namespace RemoteControlTelegramBot.Commands;

public abstract class BaseCommandHandler : ICommandHandler
{
    public ICommandHandler? NextHandler { get; set; }

    public virtual async Task HandleCommand(string command, ITelegramBotClient client, Message message,
        CancellationToken cancellationToken)
    {
        if (NextHandler != null)
            await NextHandler.HandleCommand(command, client, message, cancellationToken);
    }
}