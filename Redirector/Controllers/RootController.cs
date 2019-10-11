using System.Web;
using Microsoft.AspNetCore.Mvc;
using Redirector.Configuration;

namespace Redirector.Controllers
{
  [ApiController]
  [Route("/{**catchAll}")]
  public class RootController : ControllerBase
  {
    public IRedirectMap RedirectMap { get; }

    public RootController(IRedirectMap redirectMap)
    {
      RedirectMap = redirectMap;
    }
    
    [HttpGet]
    public ActionResult Get()
    {
      var requestPath = Request.Path;
      return RedirectMap.Mappings.TryGetValue(requestPath, out var destinationPath) 
        ? RedirectPermanent(destinationPath) 
        : Redirect(RedirectMap.DefaultDestination);
    }
    
  }
}