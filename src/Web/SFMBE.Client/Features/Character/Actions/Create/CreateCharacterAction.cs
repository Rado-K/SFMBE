namespace SFMBE.Client.Features.Character
{
  using SFMBE.Client.Features.Base;

  internal partial class CharacterState
  {
    public class CreateCharacterAction : BaseAction
    {
      public string CharacterName { get; set; }
    }
  }
}
