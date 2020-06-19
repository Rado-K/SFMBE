namespace SFMBE.Client.Features.Character
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Repositories.Characters;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class CharacterState
  {
    internal class CreateCharacterHandler : BaseHandler<CreateCharacterAction>
    {
      private readonly ICharactersRepository charactersRepository;
      private readonly IMediator mediator;

      public CreateCharacterHandler(ICharactersRepository charactersRepository, IMediator mediator, IStore store) : base(store)
      {
        this.charactersRepository = charactersRepository;
        this.mediator = mediator;
      }

      public override async Task<Unit> Handle(CreateCharacterAction action, CancellationToken cancellationToken)
      {
        var characterCreatedResponse = await this.charactersRepository.CreateCharacter(action.CharacterName);

        if (characterCreatedResponse.IsOk)
        {
          await this.mediator.Send(new FetchCharacterAction());
        }

        return await Unit.Task;
      }
    }
  }
}
