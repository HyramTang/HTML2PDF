// See https://aka.ms/new-console-template for more information

using DinkToPdf;
using System;

var converter = new BasicConverter(new PdfTools());
var contentCSS= File.ReadAllText(@"Content\test.css");
var contentHTML = File.ReadAllText(@"Content\test.html");
var content = contentCSS + contentHTML;



var doc = new HtmlToPdfDocument()
{
    GlobalSettings = {
        ColorMode = ColorMode.Color,
        Orientation = Orientation.Portrait,
        PaperSize = PaperKind.A4,
    },
    Objects = {
        new ObjectSettings() {
            PagesCount = true,
            HtmlContent = content,//@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. In consectetur mauris eget ultrices  iaculis. Ut                               odio viverra, molestie lectus nec, venenatis turpis.",
            WebSettings = { DefaultEncoding = "utf-8" },
            HeaderSettings = { 
                //FontSize = 9, 
                //Right = "Page [page] of [toPage]", 
                //Line = true, 
                //Spacing = 2.812 
            }
        }
    }
};

byte[] pdf = converter.Convert(doc);

File.WriteAllBytes("test.pdf", pdf); // Requires System.IO

Console.WriteLine("Hello, World!");
