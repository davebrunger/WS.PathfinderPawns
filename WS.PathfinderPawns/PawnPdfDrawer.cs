namespace WS.PathfinderPawns;

public static class PawnPdfDrawer
{
    public static void DrawPawnPdf(FileInfo imageFile, FileInfo outputFile, PageSize paperSize, PawnSize pawnSize)
    {
        using var document = new PdfDocument();
        var page = document.AddPage();
        page.Size = paperSize;
        page.Orientation = PageOrientation.Portrait;
        using var image = XImage.FromFile(imageFile.FullName);
        DrawPawGrid(page, pawnSize, image);
        document.Save(outputFile.FullName);
    }
    
    private static void DrawPawGrid(PdfPage page, PawnSize pawnSize, XImage image)
    {
        PawnGridDrawer.DrawPawnGrid(page, pawnSize, _ => image);
    }
}