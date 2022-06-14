using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BeerHub.ErrorAndAuthModels
{
  public class HttpStatusException : Exception
  {
    public HttpStatusCode StatusCode { get; set; }

    public HttpStatusException(HttpStatusCode statusCode, string message) : base(message)
    {
      StatusCode = statusCode;
    }

  }
}
