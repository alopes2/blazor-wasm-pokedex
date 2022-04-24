using MatBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pokedex;
using Pokedex.Clients;
using Pokedex.Configurations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMatBlazor();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var pokeApiOptions = builder.Configuration
                        .GetSection(PokeApiOptions.Name)
                        .Get<PokeApiOptions>();

builder.Services.AddHttpClient<PokeClient>(options =>
{
    options.BaseAddress = pokeApiOptions.BaseAddress;
});

await builder.Build().RunAsync();