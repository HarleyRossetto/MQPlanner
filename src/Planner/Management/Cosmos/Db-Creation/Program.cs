using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.Cosmos;

Console.WriteLine("Macquarie Planner: CosmosDB Creation Tool.");

var userAssignedClientIdOption = new Option<string>("--uid", "Azure User Assigned Client ID");
var dbNameOption = new Option<string>("--databaseName", "Name of database to create in instance.");
var kvNameOption = new Option<string>("--kvName", "Name of keyvault to retrieve cosmos keys from..");

var createCommand = new Command("create")
{
    userAssignedClientIdOption,
    kvNameOption,
    dbNameOption
};
//createCommand.Handler = Handler.Create<string, string, string, CreateCosmosDatabaseAsync);
createCommand.Handler = CommandHandler.Create<string, string, string>(CreateCosmosDatabaseAsync);

var rootCommand = new RootCommand() {
    createCommand
};
await rootCommand.InvokeAsync(args);

static async Task CreateCosmosDatabaseAsync(string uid, string kvName, string databaseName) {
    if (string.IsNullOrWhiteSpace(uid)) {
        System.Console.WriteLine("--uid cannot be null or empty.");
        return;
    }
     if (string.IsNullOrWhiteSpace(kvName)) {
        System.Console.WriteLine("--kvName cannot be null or empty.");
        return;
    }
    if (string.IsNullOrWhiteSpace(databaseName)) {
        System.Console.WriteLine("--name cannot be null or empty.");
        return;
    }

    var kvSecret = new SecretClient(
        new Uri($"https://{kvName}.vault.azure.net"),
        new DefaultAzureCredential(
             new DefaultAzureCredentialOptions() { ManagedIdentityClientId = uid }));

    var connectionUri = await kvSecret.GetSecretAsync("Secret-cosmos-handbookdb-rw");
    string uriString = connectionUri.Value.Value;

    var cosmosClient = new CosmosClient(uriString,
                                        new CosmosClientOptions() { 
                                            ApplicationRegion = Regions.AustraliaEast 
                                        });
    
    var database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);

    switch (database.StatusCode) {
        case System.Net.HttpStatusCode.Created:
            System.Console.WriteLine($"Database with name {databaseName} successfully created.");
            break;
        case System.Net.HttpStatusCode.OK:
            System.Console.WriteLine($"Database with name {databaseName} already exists.");
            break;
    }

    System.Console.WriteLine();

    return;
}



