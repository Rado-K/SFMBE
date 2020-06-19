namespace SFMBE.Client.Pipeline
{
  using BlazorState;
  using Dawn;
  using MediatR;
  using Microsoft.Extensions.Logging;
  using System;
  using System.Threading;
  using System.Threading.Tasks;

  public class MyBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  {
    private readonly ILogger logger;

    public Guid Guid { get; } = Guid.NewGuid();

    public MyBehavior(ILogger<MyBehavior<TRequest, TResponse>> logger)
    {
      this.logger = logger;
      this.logger.LogDebug($"{GetType().Name}: Constructor");
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
      Guard.Argument(next, nameof(next)).NotNull();

      logger.LogDebug($"{GetType().Name}: Start");

      logger.LogDebug($"{GetType().Name}: Call next");
      TResponse newState = await next();
      logger.LogDebug($"{GetType().Name}: Start Post Processing");
      // Constrain here based on a type or anything you want.
      if (typeof(IState).IsAssignableFrom(typeof(TResponse)))
      {
        logger.LogDebug($"{GetType().Name}: Do Constrained Action");
      }

      logger.LogDebug($"{GetType().Name}: End");
      return newState;
    }
  }
}
