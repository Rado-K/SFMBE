namespace SFMBE.Shared.Application
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  public class ApplicationStartResponseModel
  {
    public string Username { get; set; }

    public DateTime VersionBuiltOn { get; set; }

    public string EnvironmentName { get; set; }
  }
}
