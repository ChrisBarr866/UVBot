var builder = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", true, true);

var config = builder.Build();
var connectionString = config["ConnectionString"];

var botClient = new TelegramBotClient(connectionString);

var me = botClient.GetMeAsync().Result;
Console.WriteLine("Hello! My name is {0}", me.FirstName);
