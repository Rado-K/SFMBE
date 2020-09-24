namespace SFMBE.Client.Features.Characters
{
  using SFMBE.Client.Features.Base;

  internal partial class CharactersState
  {
    public class CreateCharacterAction : BaseAction
    {
      public string CharacterName { get; set; }
    }
  }
}