using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Endpoints.Filters;
using Portfolio.Api.Endpoints.Helpers;
using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;

namespace Portfolio.Api.Endpoints;

public class ContactMessagesEndpoint : IEndpoint
{
    private const string conTactMessageEndpointTag = "ContactMessage";
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        var contactMessageGroup = routeBuilder.MapGroup(conTactMessageEndpointTag.ToLower()).WithTags(conTactMessageEndpointTag);
        
        contactMessageGroup.MapGet(string.Empty, async ([FromServices] IContactMessageService contactMessageService, HttpContext context) =>
        {
            return await contactMessageService.GetAllContactMessageAsync();
        });

        contactMessageGroup.MapGet("/{contactMessageId:int}", async (int contactMessageId, [FromServices]IContactMessageService contactMessageService) => await contactMessageService.GetContactMessageByIdAsync(contactMessageId));
       
        contactMessageGroup.MapPost(string.Empty, async ([FromBody]ContactMessageDto contactMessageDto, [FromServices] IContactMessageService contactMessageService) =>
        {
            return await contactMessageService.AddContactMessageAsync(contactMessageDto);
        }).AddEndpointFilter<ValidationFilter<ContactMessageDto>>();

        contactMessageGroup.MapDelete("/{contactMessageId:int}", async (int contactMessageId, [FromServices] IContactMessageService contactMessageService) => await contactMessageService.DeleteContactMessageAsync(contactMessageId));

        contactMessageGroup.MapPut("/{contactMessageId:int}", async (int contactMessageId,ContactMessageDto contactMessageDto, [FromServices] IContactMessageService contactMessageService) => await contactMessageService.UpdateContactMessageAsync(contactMessageId,contactMessageDto));

        return routeBuilder;
    }
}
