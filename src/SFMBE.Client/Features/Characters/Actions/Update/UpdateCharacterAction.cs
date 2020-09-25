namespace SFMBE.Client.Features.Characters
{
  using SFMBE.Client.Features.Base;
  using SFMBE.Shared.Characters.Commands;

  internal partial class CharactersState
  {
    public class UpdateCharacterAction : BaseAction
    {
      public UpdateCharacterCommand Character { get; set; }
    }
  }
}
