using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using BinanceExchange.API.Client.Interfaces;
using System.Reactive.Linq;
using CoinMarketCap;
using System.Diagnostics;
using AutoMapper;
using System.Threading.Tasks;
using LedgerLocal.Service.ChainService;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class BotService : IBotService
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly ILogger<BotService> _logger;

        private readonly ITelegramClientFactory _telegramClientFactory;

        private IServiceProvider _serviceProvider;
        private CoinMarketCapClient _coinMarketCapClient;
        private DateTime _startDate;
        private IAccountService _accountService;

        private long _currentChatId = 0;
        private long _currentPublicChatId = 0;
        private bool _started;
        private IMapper _mapper;

        public BotService(ITelegramBotClient telegramBotClient,
            IServiceProvider serviceProvider,
            MapperConfiguration mapperConfig,
            ITelegramClientFactory telegramClientFactory,
            IAccountService accountService,
            ILogger<BotService> logger)
        {

            _telegramBotClient = telegramBotClient;
            _logger = logger;
            _mapper = mapperConfig.CreateMapper();
            _serviceProvider = serviceProvider;
            _telegramClientFactory = telegramClientFactory;
            _accountService = accountService;

            _started = false;
            Running = true;
        }

        public bool IsStarted { get { return _started; } }

        public bool Running { get; set; }

        public void Start()
        {
            _startDate = DateTime.UtcNow;

            _logger.LogInformation("Starting Telegram Bot");

            _telegramBotClient.OnMessage += BotOnMessageReceived;
            _telegramBotClient.OnMessageEdited += BotOnMessageReceived;

            //_telegramBotClient.OnCallbackQuery += BotOnCallbackQueryReceived;
            //_telegramBotClient.OnInlineQuery += BotOnInlineQueryReceived;
            //_telegramBotClient.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            //_telegramBotClient.OnReceiveError += BotOnReceiveError;

            var me = _telegramBotClient.GetMeAsync().Result;

            Console.Title = me.Username;

            _logger.LogInformation($"Telegram Bot testing connection => {me.Username}");

            _coinMarketCapClient = new CoinMarketCapClient();

            _telegramBotClient.StartReceiving();

            _started = true;

            _logger.LogInformation("Telegram Bot started");
        }

        public void Stop()
        {
            Running = false;

            _logger.LogInformation("Telegram Bot stopping");
            _telegramBotClient.StopReceiving();
            _started = false;
            _logger.LogInformation("Telegram Bot stopped");
        }

        public async Task SendMessage(string msg)
        {
            await _telegramBotClient.SendTextMessageAsync(
                _currentChatId,
                msg,
                replyMarkup: new ReplyKeyboardRemove());
        }

        private void SendToLog(string message)
        {
            _logger.LogInformation("[Telegram] => {Message}", message);
        }

        public async void ProcessMessage(string msg1, long channelId, bool isPublic = false)
        {
            try
            {
                var arInput = msg1.Split(' ');

                switch (arInput.First())
                {
                    case "/rebootSafe":

                        var msgT1 = "rebooting bot ...";

                        await _telegramBotClient.SendTextMessageAsync(
                            channelId,
                            msgT1,
                            replyMarkup: new ReplyKeyboardRemove());

                        SendToLog(msgT1);

                        var process = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "dotnet",
                                Arguments = @"D:\7\LedgerLocal.Scheduler\Src-LedgerLocal.Scheduler.Core\LedgerLocal.Scheduler.Console\bin\Release\PublishOutput\LedgerLocal.Scheduler.Console.dll",
                                UseShellExecute = true,
                                RedirectStandardOutput = false,
                                RedirectStandardError = false,
                                CreateNoWindow = true
                            }

                        };

                        process.Start();

                        // Closes the current process
                        Environment.Exit(0);
                        break;

                    case "/history":

                        var resHisto = await _accountService.ListHistory("tst-ll-admin", 10);

                        await _telegramBotClient.SendTextMessageAsync(
                            channelId,
                            JsonConvert.SerializeObject(resHisto, Formatting.Indented),
                            replyMarkup: new ReplyKeyboardRemove());
                        break;

                    case "/info":

                        await _telegramBotClient.SendTextMessageAsync(
                            channelId,
                            "[LedgerLocal] Ready to rock",
                            replyMarkup: new ReplyKeyboardRemove());
                        break;

                    default:
                        const string usage = @"
[LedgerLocal] =>

/totalAmountRaised

/history
/info

";

                        await _telegramBotClient.SendTextMessageAsync(
                            channelId,
                            usage,
                            replyMarkup: new ReplyKeyboardRemove());
                        break;
                }
                }
            catch(Exception ex1)
            {
                _logger.LogError(ex1, "Error process msg1");
            }
        }

        private void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            try
            {
                var now = DateTime.UtcNow;

                var message = messageEventArgs.Message;

                _currentChatId = messageEventArgs.Message.Chat.Id;
                _currentPublicChatId = messageEventArgs.Message.Chat.Id;

                if (message == null || message.Type != MessageType.Text) return;

                //IReplyMarkup keyboard = new ReplyKeyboardRemove();

                var inputTxtString = message.Text;

                ProcessMessage(inputTxtString, message.Chat.Id);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
            }
        }

        public long CurrentChannelId()
        {
            return _currentChatId;
        }
    }
}
