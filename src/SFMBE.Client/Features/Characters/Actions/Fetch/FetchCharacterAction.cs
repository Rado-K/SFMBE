namespace SFMBE.Client.Features.Characters
{
  using SFMBE.Client.Features.Base;

  internal partial class CharacterState
  {
    public class FetchCharacterAction : BaseAction
    {
      public int CharacterId { get; set; }
    }
  }
}