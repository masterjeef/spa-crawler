using System;
using System.IO;
using System.Threading.Tasks;

using PuppeteerSharp;

namespace SpaCrawler.Console
{
    public static class Startup
    {
        public static async Task Main()
        {
            var options = new LaunchOptions
            {
                Headless = true
            };

            System.Console.WriteLine("Downloading chromium");
            await Downloader.CreateDefault().DownloadRevisionAsync(Downloader.DefaultRevision);

            var uri = "http://localhost:5555";
            System.Console.WriteLine($"Navigating to {uri}");
            using (var browser = await Puppeteer.LaunchAsync(options, Downloader.DefaultRevision))
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync(uri);

                var content = await page.GetContentAsync();
                System.Console.WriteLine($"page content: {content}");

                var path = Path.Combine(Directory.GetCurrentDirectory(), $"{Guid.NewGuid()}.pdf");
                await page.PdfAsync(path);
            }

            System.Console.WriteLine("Press enter to quit:");
            System.Console.Read();
        }
    }
}