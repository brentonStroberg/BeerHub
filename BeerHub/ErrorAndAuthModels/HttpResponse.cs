using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BeerHub.ErrorAndAuthModels
{
  public class HttpResponse : Exception
  {
    public HttpStatusCode StatusCode { get; set; }

    public HttpResponse(HttpStatusCode statusCode, string message) : base(message)
    {
      StatusCode = statusCode;
    }

  }
}
