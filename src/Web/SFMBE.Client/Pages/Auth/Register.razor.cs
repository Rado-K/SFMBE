﻿namespace SFMBE.Client.Pages.Auth
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Infrastructure.Auth;
  using SFMBE.Client.Respository.Accounts;
  using SFMBE.Shared;
  using SFMBE.Shared.Account;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class Register
  {
    private readonly UserRegisterRequestModel userLoginRequestModel = new UserRegisterRequestModel();

    private ApiResponse<UserRegisterResponseModel> response;

    [Inject] public IAccountRepository AccountRepository { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public ILoginService LoginService { get; set; }

    private async Task CreateUser()
    {
      this.response = await this.AccountRepository.Register(this.userLoginRequestModel);

      if (this.response.IsOk)
      {
        this.NavigationManager.NavigateTo("/login");
      }
    }
  }
}