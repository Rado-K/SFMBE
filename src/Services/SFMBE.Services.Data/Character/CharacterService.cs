﻿namespace SFMBE.Services.Data.Character
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.User;
  using SFMBE.Shared.Character;
  using SFMBE.Shared.Items;
  using System.Linq;
  using System.Threading.Tasks;

  public class CharacterService : ICharacterService
  {
    private readonly IRepository<Character> characterRepository;
    private readonly IUserService userService;

    public CharacterService(IRepository<Character> characterRepository, IUserService userService)
    {
      this.characterRepository = characterRepository;
      this.userService = userService;
    }

    public async Task<CharacterResponseModel> GetCharacterById(int characterId)
    {
      var character = await this.characterRepository
        .All()
        .Where(x => x.Id == characterId)
        .Select(x =>
            new CharacterResponseModel
            {
              Agility = x.Agility,
              Bag =
                new Shared.Bags.BagResponseModel
                {
                  Items = x.Bag.Items.Select(i =>
                      new ItemResponseModel
                      {
                        Id = i.Id
                      })
                  .ToList()
                },
              Gear =
                new Shared.Gear.GearResponseModel
                {
                  EquippedItems = x.Gear.EquippedItems.Select(i =>
                      new ItemResponseModel
                      {
                        Id = i.Id
                      })
                  .ToList()
                },
              Experience = x.Experience,
              Image = x.Image,
              Intelligence = x.Intelligence,
              Level = x.Level,
              Money = x.Money,
              Name = x.Name,
              Stamina = x.Stamina,
              Strength = x.Strength
            })
        //.To<CharacterResponseModel>()
        .FirstOrDefaultAsync();

      return character;
    }

    public async Task<int> CreateCharacter(string name)
    {
      var character = new Character { Name = name };
      var user = await this.userService.GetUser();
      user.Character = character;

      await this.characterRepository.AddAsync(character);
      await this.characterRepository.SaveChangesAsync();

      return character.Id;
    }

    public async Task<Character> GetCurrentCharacter()
    {
      var user = await this.userService.GetUser();

      return user.Character;
    }
  }
}
