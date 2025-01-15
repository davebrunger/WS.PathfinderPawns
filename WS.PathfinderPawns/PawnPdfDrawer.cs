using System.Collections.Immutable;

namespace WS.PathfinderPawns;

public static class PawnPdfDrawer
{
    private static readonly ImmutableList<XColor> DotColours = [
        XColor.FromArgb(255, 0, 0),
        XColor.FromArgb(0, 255, 0),
        XColor.FromArgb(0, 0, 255),
        XColor.FromArgb(255, 255, 0),
        XColor.FromArgb(255, 0, 255),
        XColor.FromArgb(0, 255, 255),
        XColor.FromArgb(0, 0, 0)
    ];
    
    public static void DrawPawnPdf(FileInfo[] imageFiles, FileInfo outputFile, PageSize paperSize, PawnSize pawnSize, bool drawDots = true)
    {
        using var document = new PdfDocument();
        var page = document.AddPage();
        page.Size = paperSize;
        page.Orientation = PageOrientation.Portrait;
        XImage.FromFile(imageFiles[0].FullName);
        PawnGridDrawer.DrawPawnGrid(page, pawnSize, 
            (index, total) =>
            {
                var imagesPerImageFile = total / imageFiles.Length;
                var imageIndex = index / imagesPerImageFile;
                imageIndex = imageIndex >= imageFiles.Length ? imageFiles.Length - 1 : imageIndex;
                return XImage.FromFile(imageFiles[imageIndex].FullName);
            },
            (index, total) =>
            {
                var imagesPerImageFile = total / imageFiles.Length;
                var imageIndex = index % imagesPerImageFile / 2 % DotColours.Count;
                return DotColours[imageIndex];
            });
        document.Save(outputFile.FullName);
    }
   
}