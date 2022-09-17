using Telegram.Bot;
using Message = Telegram.Bot.Types.Message;

namespace RemoteControlTelegramBot.Commands;

public interface ICommandHandler
{
    public Task HandleCommand(string command, ITelegramBotClient client, Message message, CancellationToken cancellationToken);
}