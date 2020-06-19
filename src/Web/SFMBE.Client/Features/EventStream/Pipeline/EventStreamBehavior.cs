namespace SFMBE.Client.Features.EventStream
{
  using Dawn;
  using MediatR;
  using Microsoft.Extensions.Logging;
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using SFMBE.Client.Infrastructure.Base;
  using static SFMBE.Client.Features.EventStream.EventStreamState;

  public class EventStreamBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  {
    private readonly ILogger logger;
    private readonly IMediator mediator;
    public Guid Guid { get; } = Guid.NewGuid();

    public EventStreamBehavior(ILogger<EventStreamBehavior<TRequest, TResponse>> aLogger, IMediator aMediator)
    {
      this.logger = aLogger;
      this.mediator = aMediator;
      this.logger.LogDebug($"{GetType().Name}: Constructor");
    }

    public async Task<TResponse> Handle(TRequest aRequest, CancellationToken aCancellationToken, RequestHandlerDelegate<TResponse> aNext)
    {
      Guard.Argument(aNext, nameof(aNext)).NotNull();

      await this.AddEventToStream(aRequest, "Start");
      TResponse newState = await aNext();
      await this.AddEventToStream(aRequest, "Completed");
      return newState;
    }

    private async Task AddEventToStream(TRequest aRequest, string tag)
    {
      if (!(aRequest is AddEventAction)) //Skip to avoid recursion
      {
        var addEventAction = new AddEventAction();
        string requestTypeName = aRequest.GetType().Name;

        if (aRequest is BaseRequest request)
        {
          addEventAction.Message = $"{tag}:{requestTypeName}:{request.Id}";
        }
        else
        {
          addEventAction.Message = $"{tag}:{requestTypeName}";
        }
        await this.mediator.Send(addEventAction);
      }
    }
  }
}
