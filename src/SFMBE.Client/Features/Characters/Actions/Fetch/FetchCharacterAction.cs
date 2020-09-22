namespace SFMBE.Client.Features.Characters
{
  using SFMBE.Client.Features.Base;

  internal partial class CharactersState
  {
    public class FetchCharacterAction : BaseAction
    {
      public int CharacterId { get; set; }
    }
  }
}
