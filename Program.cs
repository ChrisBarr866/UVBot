// get current directory

var builder = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json", true, true);

var config = builder.Build();

var connectionString = config["TelegramBotKey"];

var botClient = new TelegramBotClient(connectionString);

var me = botClient.GetMeAsync().Result;
Console.WriteLine(connectionString);

var client = new HttpClient();
var httpRequestMessage = new HttpRequestMessage
{
        Method = HttpMethod.Get,
        RequestUri = new Uri("https://api.openuv.io/api/v1/uv"),
        Headers = { 
            { "x-access-token", config["UVApiKey"] },
        },
    };

var response = client.SendAsync(httpRequestMessage).Result;
var responseBody = response.Content.ReadAsStringAsync().Result;

Console.WriteLine(responseBody);
Console.WriteLine("Hello! My name is {0}", me.FirstName);
