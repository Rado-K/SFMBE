﻿namespace SFMBE.Services.Data.Settings
{
  using System.Collections.Generic;

  public interface ISettingsService
  {
    int GetCount();

    IEnumerable<T> GetAll<T>();
  }
}
