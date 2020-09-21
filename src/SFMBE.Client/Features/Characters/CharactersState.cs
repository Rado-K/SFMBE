namespace SFMBE.Client.Features.Characters
{
  using BlazorState;
  using SFMBE.Shared.Characters.Queries;

  internal partial class CharactersState : State<CharactersState>
  {
    public GetCharacterQueryResponse Character { get; set; }

    public override void Initialize() { }
  }
}
