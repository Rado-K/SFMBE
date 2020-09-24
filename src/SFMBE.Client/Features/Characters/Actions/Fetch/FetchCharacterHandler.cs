namespace SFMBE.Client.Features.Characters
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared.Characters.Queries;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class CharactersState
  {
    internal class FetchCharacterHandler : BaseHandler<FetchCharacterAction>
    {
      private readonly IHttpService httpService;

      public FetchCharacterHandler(IHttpService httpService, IStore store) : base(store)
      {
        this.httpService = httpService;
      }

      public override async Task<Unit> Handle(FetchCharacterAction action, CancellationToken cancellationToken)
      {
        var characterResponse = await this.httpService.GetJson<GetCharacterQueryResponse>("api/Characters/Get");

        if (characterResponse.IsOk)
        {   
          this.CharacterState.Character = characterResponse.Data;
          this.BagsState.Bag = this.CharacterState.Character.Bag;
          this.GearsState.Gear = this.CharacterState.Character.Gear;
        }

        return await Unit.Task;
      }
    }
  }
}
