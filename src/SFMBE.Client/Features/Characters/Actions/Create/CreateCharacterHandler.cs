namespace SFMBE.Client.Features.Characters
{
  using System.Threading.Tasks;
  using System.Threading;
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Infrastructure.Http;

  internal partial class CharactersState
  {
    internal class CreateCharacterHandler : BaseHandler<CreateCharacterAction>
    {
      private readonly IHttpService httpService;
      private readonly IStore store;

      public CreateCharacterHandler(IHttpService httpService, IStore store) : base(store)
      {
        this.httpService = httpService;
        this.store = store;
      }

      public override async Task<Unit> Handle(CreateCharacterAction action, CancellationToken cancellationToken)
      {
        var characterCreatedResponse = await this.httpService.PostJson<string, int>($"api/Characters/Create", action.CharacterName);

        return await Unit.Task;
      }
    }
  }
}