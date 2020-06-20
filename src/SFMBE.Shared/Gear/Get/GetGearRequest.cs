using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMBE.Shared.Gear.Get
{
  public class GetGearRequest : IRequest<ApiResponse<GetGearResponse>>
  {
    public const string Route = "api/gears";

    public int GearId { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}?{nameof(this.GearId)}={this.GearId}";
  }
}
