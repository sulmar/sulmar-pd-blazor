using System;
using Domain.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Pages;

public partial class Tickets
{
     string title = "Tickets";

    [Inject]
    public ITicketRepository repository {get; set; }

    IEnumerable<Ticket> tickets = Enumerable.Empty<Ticket>();
        

    protected override void OnInitialized()
    {
        tickets = repository.GetAll();

    }
}

