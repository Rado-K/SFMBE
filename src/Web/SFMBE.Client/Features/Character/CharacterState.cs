namespace SFMBE.Client.Features.Character
{
  using BlazorState;
  using SFMBE.Shared;
  using SFMBE.Shared.Character;

  internal partial class CharacterState : State<CharacterState>
  {
    public ApiResponse<CharacterResponseModel> Character { get; set; }

    public override void Initialize() { }
  }
}
