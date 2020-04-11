namespace SFMBE.Web.Areas.Administration.Controllers
{
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Common;
  using SFMBE.Web.Controllers;

  [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
  [Area("Administration")]
  public class AdministrationController : BaseController
  {
  }
}
