namespace SFMBE.Client.Features.Character
{
  using BlazorState;
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Get;

  internal partial class CharacterState : State<CharacterState>
  {
    public ApiResponse<GetCharacterResponse> Character { get; set; }

    public override void Initialize() { }
  }
}
