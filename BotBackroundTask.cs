using Telegram.Bot;
using Telegram.Bot.Polling;


public class BotBackroundTask : BackgroundService
{
    private ILogger<BotBackroundTask> logger;
    private readonly ITelegramBotClient botClient;
    private readonly IUpdateHandler updateHandler;

    public BotBackroundTask
    (ILogger<BotBackroundTask> logger,
    ITelegramBotClient botClient,
    IUpdateHandler updateHandler)
   {
    this.logger = logger;
    this.botClient = botClient;
    this.updateHandler = updateHandler;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var me = await botClient.GetMeAsync(stoppingToken);
        logger.LogInformation("Bot startded:{username}",me.Username);

        botClient.StartReceiving
        (
            updateHandler : updateHandler,
            receiverOptions: default,
            cancellationToken : stoppingToken
        );
        
    }
}