﻿namespace SFMBE.Shared.Character.Update
{
  using Data.Models;
  using MediatR;
  using Newtonsoft.Json;
  using Services.Mapping;
  using SFMBE.Shared.Character.Get;

  public class UpdateCharacter :
    IMapFrom<GetCharacterResponse>,
    IMapTo<Character>,
    IMapFrom<Character>,
    IRequest<ApiResponse<UpdateCharacter>>
  {
    public const string Route = "api/characters/update";

    public string Name { get; set; }

    public int Level { get; set; }

    public int Money { get; set; }

    public int Experience { get; set; }

    public int Stamina { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    public int Strength { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}";
  }
}
