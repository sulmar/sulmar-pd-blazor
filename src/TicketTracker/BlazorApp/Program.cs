using BlazorApp.Components;
using BlazorApp.Services;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

// builder.Configuration.AddJsonFile("krzysztof.json", optional: true);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents(); //dotnet add package Microsoft.AspNetCore.Components.WebAssembly.Server


builder.Services.AddScoped<ITicketRepository, FakeTicketRepository>();

builder.Services.AddScoped<IEnumerable<Ticket>>(_ => new List<Ticket>
        {
            new Ticket { Id = 1, Title = "Lorem", Description="Ipsum", CreatedBy = "John"},
            new Ticket { Id = 2, Title = "Ipsum", Description="Ipsum",CreatedBy = "Adam"},
            new Ticket { Id = 3, Title = "Deres", Description="Ipsum",CreatedBy = "Kate" },
            new Ticket { Id = 4, Title = "Veto",Description="Ipsum", CreatedBy = "Bob" },
            new Ticket { Id = 5, Title = "Alfa", Description="Ipsum",CreatedBy = "John" },
        });

builder.Services.AddScoped<IUserRepository, FakeUserRepository>();
builder.Services.AddScoped<IEnumerable<User>>(_ => new List<User>
{
    new User { Id = 1, FirstName = "John", LastName = "Smith"},
    new User { Id = 2, FirstName = "Kate", LastName = "Smith"},
    new User { Id = 3, FirstName = "Bob", LastName = "Smith"},    
});      

builder.Services.AddSingleton<AppState>();


string npbApi = builder.Configuration["NbpApi"];

Console.WriteLine(npbApi);

string baseAddress = builder.Configuration["BaseAddress"];

builder.Services.AddScoped(sp=>new HttpClient { BaseAddress = new Uri(baseAddress)});

builder.Services.AddScoped<UserApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();


app.MapGet("/api/users", (IUserRepository repository) => repository.GetAll() );

app.Run();
