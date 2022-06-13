using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.ErrorAndAuthModels
{
  public class ErrorResponse
  {
    public string Message { get; set; }

    public ErrorResponse(Exception ex)
    {
      Message = ex.Message;
    }
  }
}
