using System;
using Microsoft.AspNetCore.Mvc;

namespace apirest.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EnvironmentController : ControllerBase
  {
    [HttpGet("{name}")]
    public GetEnvironmentDto Get(string name)
    {
      var environment = Environment.GetEnvironmentVariable(name);
      if (environment == null)
      {
        environment = "NOT FOUND";
      }
      return new GetEnvironmentDto { Name = name, Value = environment };
    }
  }
}
