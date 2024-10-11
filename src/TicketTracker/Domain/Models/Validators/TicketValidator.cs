using FluentValidation;

namespace Domain.Models.Valiators;

// dotnet add package FluentValidations
public class TicketValidator : AbstractValidator<Ticket>
{
    public TicketValidator()
    {
        RuleFor(p=>p.Title).NotEmpty().MinimumLength(3).WithName("Tytuł");
        RuleFor(p=>p.Description).MinimumLength(3).MaximumLength(200);
    }
}
