using PdfSharp.Drawing;
using PdfSharp.Pdf;

var imagePixelsPerInch = 300d;
var marginWidthinInches = 0.25d;

//var pathToImage = "/Users/davidbrunger/Downloads/Ghostlight V1/Ghostlight Maps/Ghostlight VTT Maps/Sewers VTT 31 wide x 39 high.jpg";
//var pathToImage = "/Users/davidbrunger/Downloads/Ghostlight V1/Ghostlight Maps/Ghostlight VTT Maps/Ghostlight's Deck VTT 20 wide x 33 high.jpg";
//var pathToImage = "/Users/davidbrunger/Downloads/Ghostlight V1/Ghostlight Maps/Ghostlight VTT Maps/The Fiddler's Green VTT 27 wide x 25 high.jpg";
//var pathToImage = "/Users/davidbrunger/Downloads/Ghostlight V1/Ghostlight Maps/Ghostlight VTT Maps/The Galley of the Damned VTT 16 wide x 25 high.jpg";

//var pathToImage = "/Users/davidbrunger/Downloads/PathfinderFlip-MatClassicsAncientDungeonDownload-JPGs/PZO31020-Ancient Dungeon.jpg";
var pathToImage = "/Users/davidbrunger/Downloads/PathfinderFlip-MatClassicsAncientDungeonDownload-JPGs/PZO31020-Ancient Dungeon2.jpg";

using var document = new PdfDocument();

using var image = XImage.FromFile(pathToImage);

var page = NewPage(document);
var imageWidthInPoints = PixelsToPoints(image.PixelWidth, imagePixelsPerInch);
var imageHeightInPoints = PixelsToPoints(image.PixelHeight, imagePixelsPerInch);

var marginWidthInPoints = marginWidthinInches * PointsPerInch();

var printablePageWidthInPoints = page.Width.Point - (marginWidthInPoints * 2);
var printablePageHeightInPoints = page.Height.Point - (marginWidthInPoints * 2);

var pagesWide = (int)Math.Ceiling(imageWidthInPoints / printablePageWidthInPoints);
var pagesHigh = (int)Math.Ceiling(imageHeightInPoints / printablePageHeightInPoints);

var totalPrinatbleWidthInPoints = printablePageWidthInPoints * pagesWide;
var totalPrintableHeightInPoints = printablePageHeightInPoints * pagesHigh;
var imageXOffsetInPoints = ((totalPrinatbleWidthInPoints - imageWidthInPoints) / 2) + marginWidthInPoints;
var imageYOffsetInPoints = ((totalPrintableHeightInPoints - imageHeightInPoints) / 2) + marginWidthInPoints;

for (var i = 0; i < pagesWide; i++)
{
    for (var j = 0; j < pagesHigh; j++)
    {
        var pageXInPoints = imageXOffsetInPoints - (i * printablePageWidthInPoints);
        var pageYInPoints = imageYOffsetInPoints - (j * printablePageHeightInPoints);
        var imageRect = new XRect(pageXInPoints, pageYInPoints, imageWidthInPoints, imageHeightInPoints);

        using var graphics = XGraphics.FromPdfPage(page);
        graphics.DrawImage(image, imageRect);

        DrawMargins(graphics, page, marginWidthInPoints);

        if (i != pagesWide - 1 || j != pagesHigh - 1)
        {
            page = NewPage(document);
        }
    }
}

static void DrawMargins(XGraphics graphics, PdfPage page, double marginWidthInPoints)
{
    var leftMargin = new XRect(0, 0, marginWidthInPoints, page.Height.Point);
    var rightMargin = new XRect(page.Width.Point - marginWidthInPoints, 0, marginWidthInPoints, page.Height.Point);
    var topMargin = new XRect(0, 0, page.Width.Point, marginWidthInPoints);
    var bottomMargin = new XRect(0, page.Height.Point - marginWidthInPoints, page.Width.Point, marginWidthInPoints);

    graphics.DrawRectangle(XBrushes.White, leftMargin);
    graphics.DrawRectangle(XBrushes.White, rightMargin);
    graphics.DrawRectangle(XBrushes.White, topMargin);
    graphics.DrawRectangle(XBrushes.White, bottomMargin);
}

Console.WriteLine($"Image size in Pixels: {image.PixelWidth} x {image.PixelHeight}");
Console.WriteLine($"Image size in Points: {imageWidthInPoints} x {imageHeightInPoints}");
Console.WriteLine($"Pages: {pagesWide} x {pagesHigh}");

document.Save("pdf.pdf");

static PdfPage NewPage(PdfDocument document)
{
    var page = document.AddPage();
    page.Size = PdfSharp.PageSize.A4;
    page.Orientation = PdfSharp.PageOrientation.Portrait;
    return page;
}

static double PixelsToPoints(double pixels, double pixelsPerInch)
{
    return pixels * PointsPerInch() / pixelsPerInch;
}

static double PointsPerInch() => 72d;
