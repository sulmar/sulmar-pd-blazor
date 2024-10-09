using BlazorApp.Components;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<ITicketRepository, FakeTicketRepository>();

builder.Services.AddScoped<IEnumerable<Ticket>>(_ => new List<Ticket>
        {
            new Ticket { Id = 1, Title = "Lorem", CreatedBy = "John"},
            new Ticket { Id = 2, Title = "Ipsum", CreatedBy = "Adam"},
            new Ticket { Id = 3, Title = "Deres", CreatedBy = "Kate" },
            new Ticket { Id = 4, Title = "Veto", CreatedBy = "Bob" },
            new Ticket { Id = 5, Title = "Alfa", CreatedBy = "John" },
        });

builder.Services.AddScoped<IUserRepository, FakeUserRepository>();
builder.Services.AddScoped<IEnumerable<User>>(_ => new List<User>
{
    new User { Id = 1, FirstName = "John", LastName = "Smith"},
    new User { Id = 2, FirstName = "Kate", LastName = "Smith"},
    new User { Id = 3, FirstName = "Bob", LastName = "Smith"},    
});      

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
    .AddInteractiveServerRenderMode();


app.MapGet("/api/users", (IUserRepository repository) => repository.GetAll() );

app.Run();
