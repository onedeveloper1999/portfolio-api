using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Endpoints.Filters;
using Portfolio.Api.Endpoints.Helpers;
using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;

namespace Portfolio.Api.Endpoints;

public class ContactsEndpoint : IEndpoint
{
    private const string contactEndpointTag = "Contact";
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        var contactGroup = routeBuilder.MapGroup(contactEndpointTag.ToLower()).WithTags(contactEndpointTag);

        contactGroup.MapGet(string.Empty, async ([FromServices] IContactService contactService, HttpContext context) =>
        {
            return await contactService.GetAllContactsAsync();
        });

        contactGroup.MapGet("/{contactId:int}", async (int contactId, [FromServices] IContactService contactService) => await contactService.GetContactByIdAsync(contactId));

        contactGroup.MapPost(string.Empty, async ([FromBody] ContactDto contactDto, [FromServices] IContactService contactService) =>
        {
            return await contactService.AddContactAsync(contactDto);
        }).AddEndpointFilter<ValidationFilter<ContactDto>>();

        contactGroup.MapDelete("/{contactId:int}", async (int contactId, [FromServices] IContactService contactService) => await contactService.DeleteContactAsync(contactId));

        contactGroup.MapPut("/{contactId:int}", async (int contactId,ContactDto contactDto, [FromServices] IContactService contactService) => await contactService.UpdateContactAsync(contactId,contactDto));

        return routeBuilder;
    }
}
