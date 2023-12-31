using Telegram.Bot;
using Telegram.Bot.Types;

public partial class UpdateHandler
{
     private Task HandleEditedMessageUpdateAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        var username = message.From?.Username ?? message.From.FirstName;
        logger.LogInformation("Received Editedmessage from {username}");
        return Task.CompletedTask;
    }
}