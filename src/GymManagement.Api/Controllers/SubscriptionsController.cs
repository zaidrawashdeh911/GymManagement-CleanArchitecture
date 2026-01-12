using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    // private readonly ISubscriptionsWriteService _subscriptionsWriteService;
    // private readonly IMediator _mediator;
    
    private readonly ISender _mediator;
    // public SubscriptionsController(ISubscriptionsWriteService subscriptionsWriteService,  Mediator mediator)
    // {
    //     _subscriptionsWriteService = subscriptionsWriteService;
    //     _mediator = mediator;
    // }
    // public SubscriptionsController(IMediator mediator)
    // {
    //     // _subscriptionsWriteService = subscriptionsWriteService;
    //     _mediator = mediator;
    // }
    public SubscriptionsController(ISender mediator)
    {
        // _subscriptionsWriteService = subscriptionsWriteService;
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        // var subscriptionId = _subscriptionsWriteService.CreateSubscription(request.SubscriptionType.ToString(), request.AdminId);
        var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.AdminId);
        
        var createSubscriptionResult = await _mediator.Send(command);

        //Same as the code below it:
        //MatchFirst is a method that receives two functions, guid is the success case, and error is the fail case
        //Match method is the same, but you can use multiple fail cases, MatchFirst takes the first fail case 
        return createSubscriptionResult.MatchFirst(
            subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
            error => Problem());

        //Same as this below:

        // if (createSubscriptionResult.IsError)
        // {
        //     return Problem();
        // }
        //
        // var response = new SubscriptionResponse(createSubscriptionResult.Value,request.SubscriptionType);
        //
        // return Ok(response);
    }
}