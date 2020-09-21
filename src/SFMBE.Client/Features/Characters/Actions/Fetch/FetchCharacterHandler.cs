namespace SFMBE.Client.Features.Character
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class CharacterState
  {
    internal class FetchCharacterHandler : BaseHandler<FetchCharacterAction>
    {

      public FetchCharacterHandler(IStore store) : base(store)
      {
        
      }

      public override async Task<Unit> Handle(FetchCharacterAction action, CancellationToken cancellationToken)
      {
        // var character = await this.charactersRepository.GetCharacter(action.CharacterId);

        // this.CharacterState.Character = character;
        // this.BagState.Bag = this.CharacterState.Character.Data.Bag;
        // this.GearState.Gear = this.CharacterState.Character.Data.Gear;

        return await Unit.Task;
      }
    }
  }
}
