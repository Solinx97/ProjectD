using ConvertApiDotNet;
using ConvertApiDotNet.Model;
using System.IO;
using System.Threading.Tasks;

namespace ReportsWebUI.Utils
{
    public static class ExcelToPDFConverter
    {
        public static async Task<FileInfo> GetConvertedResponseBySource(string filePath, string destinationFilePath)
        {
            ConvertApi convertApi = new ConvertApi("tjAqxUeQ0HuLdLI6");
            ConvertApiResponse result = await convertApi.ConvertAsync("xlsx", "pdf", new[]
            {
               new ConvertApiFileParam(filePath),
            });

            // save to file
            var fileInfo = await result.SaveFileAsync(destinationFilePath);
            return fileInfo;
        }
    }
}
