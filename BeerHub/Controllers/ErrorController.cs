using BeerHub.ErrorAndAuthModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BeerHub.Controllers
{
  [AllowAnonymous]
  [ApiExplorerSettings(IgnoreApi = true)]
  public class ErrorController : Controller
  {
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
      _logger = logger;
    }

    [Route("error")]
    public ErrorResponse Error()
    {
      var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
      var exception = context.Error;
      var code = HttpStatusCode.InternalServerError; // Default

      if (exception is HttpStatusException httpException)
      {
        code = httpException.StatusCode;
      }

      _logger.LogInformation($"{(int)code} ERROR: {exception.Message}");
      _logger.LogDebug(exception.ToString());

      Response.StatusCode = (int)code;

      return new ErrorResponse(exception);

    }
  }
}
