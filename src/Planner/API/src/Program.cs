using System.Text.Json.Serialization;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Courseloop.DataAccess;
using HXR.Utilities.DateTime;
using HXR.Utilities.DateTime.Providers;
using Newtonsoft.Json;
using Planner.Api.Services.DataAccess;
using Planner.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    // Don't include null values in return result. Save space.
    .AddJsonOptions(opt => {
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
        opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSingleton<IMacquarieHandbook, MacquarieHandbook>();
//builder.Services.AddSingleton<IMacquarieHandbook, CosmosHandbookProviderOld>();
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddSingleton<JsonSerializer>();
builder.Services.AddSingleton<IHandbookDataProvider, PlannerHandbookDataProvider>();
builder.Services.AddHttpClient<MacquarieHandbook>();
builder.Services.AddSingleton<CosmosHandbookDataProvider>();

// Configure class mappings via profile.
builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<MacquarieDtoMappingProfile>();
});

// Enable in-memory cache, check for expired items every 15 minutes minimum.
builder.Services.AddMemoryCache(options => {
    options.ExpirationScanFrequency = TimeSpan.FromMinutes(15);
    //options.SizeLimit = 1000L; // Set maximum size of cache
    // TODO Determine appropriate size for in-memory cache.
});

builder.Configuration.AddAzureKeyVault(new Uri($"https://{builder.Configuration["Azure:KeyVault:KvName"]}.vault.azure.net"),
                                        new DefaultAzureCredential(new DefaultAzureCredentialOptions() {
                                            ManagedIdentityClientId = builder.Configuration["Azure:ManagedIdentityClientId"]
                                        }),
                                        new AzureKeyVaultConfigurationOptions() {
                                            ReloadInterval = TimeSpan.FromMinutes(15)
                                        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
