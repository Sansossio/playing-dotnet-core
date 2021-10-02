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
      return new GetEnvironmentDto { Name = name, Value = Environment.GetEnvironmentVariable(name) };
    }
  }
}
