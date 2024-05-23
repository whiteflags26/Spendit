using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spendit.Models
{
    public class PdfGenerationService
    {
        public async Task<byte[]> GeneratePdfFromHtml(string htmlContent)
        {
            // Set the path to the Chromium executable
            var chromiumPath = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe";
            if (string.IsNullOrEmpty(chromiumPath))
            {
                throw new Exception("Chromium executable path is not specified.");
            }

            // Launch Puppeteer with the specified Chromium executable path
            var launchOptions = new LaunchOptions
            {
                Headless = true,
                ExecutablePath = chromiumPath // Specify the path to Chromium executable
            };

            using var browser = await Puppeteer.LaunchAsync(launchOptions);

            // Open a new page
            using var page = await browser.NewPageAsync();

            // Set HTML content
            await page.SetContentAsync(htmlContent);

            // Generate PDF
            var pdfBytes = await page.PdfDataAsync();
            await Console.Out.WriteLineAsync(pdfBytes.ToString());
            return pdfBytes;
        }
    }
}
