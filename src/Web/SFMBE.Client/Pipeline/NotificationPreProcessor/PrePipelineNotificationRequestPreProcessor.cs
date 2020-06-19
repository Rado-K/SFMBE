namespace SFMBE.Client.Pipeline.NotificationPreProcessor
{
  using MediatR;
  using MediatR.Pipeline;
  using Microsoft.Extensions.Logging;
  using System.Threading;
  using System.Threading.Tasks;

  internal class PrePipelineNotificationRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
  {
    private readonly ILogger logger;

    private readonly IMediator mediator;

    public PrePipelineNotificationRequestPreProcessor(ILogger<PrePipelineNotificationRequestPreProcessor<TRequest>> logger, IMediator mediator)
    {
      this.logger = logger;
      this.mediator = mediator;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
      var notification = new PrePipelineNotification<TRequest>
      {
        Request = request,
      };

      logger.LogDebug("PrePipelineNotificationRequestPreProcessor");
      await this.mediator.Publish(notification, cancellationToken);
    }
  }
}
