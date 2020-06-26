namespace SFMBE.Shared.Items.GetItems
{
  using AutoMapper;
  using MediatR;
  using Newtonsoft.Json;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;

  public class GetItemsRequest : IMapFrom<IList<int>>, IHaveCustomMappings, IRequest<ApiResponse<GetItemsResponse>>
  {
    public const string Route = "api/items";

    public IList<int> Items { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}?{"Items=0" + string.Join("&Items=", this.Items)}";

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<IList<int>, GetItemsRequest>()
        .ForMember(d => d.Items, o => o.MapFrom(c => c));
    }
  }
}
