namespace WS.PathfinderPawns;

public static class PawnPdfDrawer
{
    public static void DrawPawnPdf(FileInfo[] imageFiles, FileInfo outputFile, PageSize paperSize, PawnSize pawnSize)
    {
        using var document = new PdfDocument();
        var page = document.AddPage();
        page.Size = paperSize;
        page.Orientation = PageOrientation.Portrait;
        XImage.FromFile(imageFiles[0].FullName);
        PawnGridDrawer.DrawPawnGrid(page, pawnSize, (index, total) =>
        {
            var imagesPerFile = total / imageFiles.Length;
            var image = index / imagesPerFile;
            image = image >= imageFiles.Length ? imageFiles.Length - 1 : image;
            return XImage.FromFile(imageFiles[image].FullName);
        });
        document.Save(outputFile.FullName);
    }
   
}