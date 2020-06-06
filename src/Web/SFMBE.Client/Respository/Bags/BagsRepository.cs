namespace SFMBE.Client.Respository.Bags
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Bags;
  using System;
  using System.Threading.Tasks;

  public partial class BagsRepository : IBagsRepository
  {
    private const string URL = "api/bags";
    private readonly IHttpService httpService;

    public event Func<Task> NotifyDataChanged;

    public BagsRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<BagResponseModel>> GetBag()
    {
      var httpResponse = await this.httpService.Get<BagResponseModel>($"{URL}");

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<BagResponseModel>(httpResponse.Errors);
      }

      return httpResponse;
    }
  }
}
