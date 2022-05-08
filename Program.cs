var builder = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", true, true);

var config = builder.Build();
var connectionString = config["ConnectionString"];
