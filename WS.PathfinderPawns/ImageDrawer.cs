namespace WS.PathfinderPawns;

public static class ImageDrawer
{
    public static void DrawImage(XGraphics gfx, double xPt, double yPt, PawnSize size, XImage image)
    {
        var (widthPt, heightPt) = size.GetPawnSize();

        var xRatio = image.PointWidth / widthPt;
        var yRatio = image.PointHeight / heightPt;
        var maxRatio = Math.Max(xRatio, yRatio);
    
        var imageWidthPt = image.PointWidth / maxRatio;
        var imageHeightPt = image.PointHeight / maxRatio;
    
        var imageXPadPt = (widthPt - imageWidthPt) / 2;
        var imageYPadPt = (heightPt - imageHeightPt) / 2;
    
        gfx.DrawImage(image, xPt + imageXPadPt, yPt + imageYPadPt, imageWidthPt, imageHeightPt);
    }
}