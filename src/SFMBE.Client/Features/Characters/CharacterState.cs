namespace SFMBE.Client.Features.Character
{
  using BlazorState;
  using SFMBE.Shared.Characters.Queries;

  internal partial class CharacterState : State<CharacterState>
  {
    public GetCharacterQueryResponse Character { get; set; }

    public override void Initialize() { }
  }
}
