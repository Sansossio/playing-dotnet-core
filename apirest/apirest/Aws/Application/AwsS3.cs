using System.IO;
using System;
using Amazon;
using Amazon.S3;
using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Aws
{
  class S3
  {
    private readonly string bucket = Environment.GetEnvironmentVariable("AWS_BUCKET");
    private readonly string region = Environment.GetEnvironmentVariable("AWS_REGION");

    private readonly AmazonS3Client s3Client = new AmazonS3Client(
      Environment.GetEnvironmentVariable("AWS_ACCESS_KEY"),
      Environment.GetEnvironmentVariable("AWS_SECRET_KEY"));

    public async Task<string> Upload(string fileName, MemoryStream data)
    {
      var item = await this.s3Client.PutObjectAsync(new PutObjectRequest
      {
        BucketName = this.bucket,
        Key = fileName,
        InputStream = data,
        CannedACL = S3CannedACL.PublicRead
      });
      return $"https://{this.bucket}.s3.{this.region}.amazonaws.com/{fileName}";
    }
  }
}
