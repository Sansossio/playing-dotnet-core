using System.IO;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace apirest.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UploadFileController : ControllerBase
  {
    private readonly Aws.S3 s3 = new Aws.S3();

    [HttpPost]
    public async Task<UploadFileDto> UploadFileToS3([FromForm] IFormFile file)
    {
      var memoryStream = new MemoryStream();
      file.CopyTo(memoryStream);

      string fileName = $"{Guid.NewGuid()}-{file.FileName}";

      return new UploadFileDto
      {
        FileUrl = await s3.Upload(fileName, memoryStream)
      };
    }
  }
}
