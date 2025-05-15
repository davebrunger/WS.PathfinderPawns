namespace WS.PathfinderMaps;

public static class MapDrawer
{
    public const double PointsPerInch = 72d;

    public static void DrawMapPdf(FileInfo imageFile, FileInfo outputFile, PageSize pageSize, double imagePixelsPerInch, double marginWidthinInches)
    {
        using var document = new PdfDocument();
        using var image = XImage.FromFile(imageFile.FullName);

        var page = NewPage(document, pageSize);
        var imageWidthInPoints = PixelsToPoints(image.PixelWidth, imagePixelsPerInch);
        var imageHeightInPoints = PixelsToPoints(image.PixelHeight, imagePixelsPerInch);

        var marginWidthInPoints = marginWidthinInches * PointsPerInch;

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
                    page = NewPage(document, pageSize);
                }
            }
        }

        document.Save(outputFile.FullName);
    }

    private static void DrawMargins(XGraphics graphics, PdfPage page, double marginWidthInPoints)
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
    private static PdfPage NewPage(PdfDocument document, PageSize pageSize)
    {
        var page = document.AddPage();
        page.Size = pageSize;
        page.Orientation = PdfSharp.PageOrientation.Portrait;
        return page;
    }

    private static double PixelsToPoints(double pixels, double pixelsPerInch)
    {
        return pixels * PointsPerInch / pixelsPerInch;
    }
}