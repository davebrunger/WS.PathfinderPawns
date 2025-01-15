namespace WS.PathfinderPawns;

public static class PawnGridDrawer
{
    public delegate XImage GetImage(int index, int total);
    
    public static void DrawPawnGrid(PdfPage page, PawnSize size, GetImage getImage, int pageBorderMm = 25, int minMarginMm = 10)
    {
        using var gfx = XGraphics.FromPdfPage(page);

        var pageWidthPt = page.Width.Point;
        var pageHeightPt = page.Height.Point;

        var (pawnWidthPt, pawnHeightPt) = size.GetPawnSize();

        var pageBorderPt = new XUnit(pageBorderMm).Point;
        var minMarginPt = new XUnit(minMarginMm).Point;

        var columns = (int)((pageWidthPt - 2 * pageBorderPt - pawnWidthPt) / (pawnWidthPt + minMarginPt) + 1);
        var rows = (int)((pageHeightPt - 2 * pageBorderPt - pawnHeightPt) / (pawnHeightPt + minMarginPt) + 1);

        var columnMarginPt = (pageWidthPt - 2 * pageBorderPt - pawnWidthPt) / (columns - 1) - pawnWidthPt;
        var rowMarginPt = (pageHeightPt - 2 * pageBorderPt - pawnHeightPt) / (rows - 1) - pawnHeightPt;

        for (var j = 0; j < rows; j++)
        {
            for (var i = 0; i < columns; i++)
            {
                var xPt = pageBorderPt + i * (pawnWidthPt + columnMarginPt);
                var yPt = pageBorderPt + j * (pawnHeightPt + rowMarginPt);
                PawnDrawer.DrawPawn(gfx, xPt, yPt, size, getImage(j * columns + i, rows * columns));    
            }
        }
    }
}