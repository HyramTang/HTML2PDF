// See https://aka.ms/new-console-template for more information

PdfConvert.ConvertHtmlToPdf(new PdfDocument
{
    Url = "http://wkhtmltopdf.org/",
    HeaderLeft = "[title]",
    HeaderRight = "[date] [time]",
    FooterCenter = "Page [page] of [topage]"

}, new PdfOutput
{
    OutputFilePath = "wkhtmltopdf-page.pdf"
});

Console.WriteLine("Hello, World!");
