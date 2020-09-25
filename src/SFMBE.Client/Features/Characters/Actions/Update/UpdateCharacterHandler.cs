namespace SFMBE.Client.Features.Characters
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Services.Mapping;

  internal partial class CharactersState
  {
    internal class UpdateCharacterHandler : BaseHandler<UpdateCharacterAction>
    {
      private readonly IHttpService httpService;

      public UpdateCharacterHandler(IHttpService httpService, IStore store): base(store)
      {
        this.httpService = httpService;
      }

      public override async Task<Unit> Handle(UpdateCharacterAction action, CancellationToken aCancellationToken)
      {
        var response = await this.httpService.PutJson("api/Characters/Update", action.Character);

        if (response.IsOk)
        {
            MappingExtensions.To(response.Data, this.CharacterState.Character);
        }

        return await Unit.Task;
      }
    }
  }
}
