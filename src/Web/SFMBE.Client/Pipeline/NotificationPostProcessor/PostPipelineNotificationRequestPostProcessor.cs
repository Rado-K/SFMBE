namespace SFMBE.Client.Pipeline.NotificationPostProcessor
{
  using MediatR;
  using MediatR.Pipeline;
  using Microsoft.Extensions.Logging;
  using System.Threading;
  using System.Threading.Tasks;

  internal class PostPipelineNotificationRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
  {
    private readonly ILogger logger;

    private readonly IMediator mediator;

    public PostPipelineNotificationRequestPostProcessor(ILogger<PostPipelineNotificationRequestPostProcessor<TRequest, TResponse>> logger, IMediator mediator)
    {
      this.logger = logger;
      this.mediator = mediator;
    }

    public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
    {
      var notification = new PostPipelineNotification<TRequest, TResponse>
      {
        Request = request,
        Response = response
      };

      logger.LogDebug("PostPipelineNotificationRequestPostProcessor");
      await this.mediator.Publish(notification, cancellationToken);
    }
  }
}
