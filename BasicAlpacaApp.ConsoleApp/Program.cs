using System.Reflection;
using Alpaca.Markets;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

const string APP_SETTINGS_CONFIGURATION_FILE = "appsettings.json";

const string ALPACA_PAPER_API_KEY_ID_CONFIGURATION_KEY = "alpaca:paper:apiKeyId";

const string ALPACA_PAPER_SECRET_KEY_CONFIGURATION_KEY = "alpaca:paper:secretKey";

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile(APP_SETTINGS_CONFIGURATION_FILE, optional: false, reloadOnChange: true)
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
    .Build();

string ALPACA_API_KEY_ID = configuration[ALPACA_PAPER_API_KEY_ID_CONFIGURATION_KEY];

string ALPACA_SECRET_KEY = configuration[ALPACA_PAPER_SECRET_KEY_CONFIGURATION_KEY];

var client = Environments
    .Paper
    .GetAlpacaTradingClient(new SecretKey(ALPACA_API_KEY_ID, ALPACA_SECRET_KEY));

var clock = await client.GetClockAsync();

if (clock != null)
{
    Console.WriteLine(
        "Timestamp: {0}, NextOpen: {1}, NextClose: {2}",
        clock.TimestampUtc, clock.NextOpenUtc, clock.NextCloseUtc);
}

// Get our account information.
var account = await client.GetAccountAsync();

// Check if our account is restricted from trading.
if (account.IsTradingBlocked)
{
    Console.WriteLine("Account is currently restricted from trading.");
}

// 200_000
Console.WriteLine(account.BuyingPower + " is available as buying power.");

