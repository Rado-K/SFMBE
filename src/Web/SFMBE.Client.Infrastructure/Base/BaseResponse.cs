namespace SFMBE.Client.Infrastructure.Base
{
  using System;

  public abstract class BaseResponse
  {
    public Guid RequestId { get; set; }

    public Guid ResponseId { get; }

    public BaseResponse(Guid requestId) : this()
    {
      this.RequestId = requestId;
    }

    public BaseResponse()
    {
      this.ResponseId = Guid.NewGuid();
    }
  }
}
