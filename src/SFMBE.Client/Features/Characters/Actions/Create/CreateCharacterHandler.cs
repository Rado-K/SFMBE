namespace SFMBE.Client.Features.Characters
{
  using System.Threading.Tasks;
  using System.Threading;
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;

  internal partial class CharactersState
  {
    internal class CreateCharacterHandler : BaseHandler<CreateCharacterAction>
    {
      private readonly IMediator mediator;

      public CreateCharacterHandler(IMediator mediator, IStore store) : base(store)
      {
        // this.charactersRepository = charactersRepository;
        this.mediator = mediator;
      }

      public override async Task<Unit> Handle(CreateCharacterAction action, CancellationToken cancellationToken)
      {
        // var characterCreatedResponse = await this.charactersRepository.CreateCharacter(action.CharacterName);

        // if (characterCreatedResponse.IsOk)
        // {
        //   await this.mediator.Send(new FetchCharacterAction { CharacterId = characterCreatedResponse.Data.Id });
        // }

        return await Unit.Task;
      }
    }
  }
}