namespace SFMBE.Shared.Base
{
  using System;

  public abstract class BaseRequest
  {
    public Guid Id { get; set; }

    public BaseRequest()
    {
      Id = Guid.NewGuid();
    }
  }
}
