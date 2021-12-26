// See https://aka.ms/new-console-template for more information
using PuppeteerSharp;
using PuppeteerSharp.Media;

Console.WriteLine("Hello, World!");


var contentCSS = File.ReadAllText(@"Content\test.css");
var contentHTML = File.ReadAllText(@"Content\test.html");
var content = contentCSS + contentHTML;

await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);

await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Headless = true
});

await using var page = await browser.NewPageAsync();
await page.EmulateMediaTypeAsync(MediaType.Screen);
await page.SetContentAsync(content);
var pdfContent = await page.PdfStreamAsync(new PdfOptions
{
    Format = PaperFormat.A4,
    PrintBackground = true
});


using (FileStream outputFileStream = new FileStream("test.pdf", FileMode.Create))
{
    pdfContent.CopyTo(outputFileStream);
}


