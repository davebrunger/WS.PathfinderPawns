namespace WS.PathfinderPawns;

public static class PawnDrawer
{
    public static void DrawPawn(XGraphics gfx, double xPt, double yPt, PawnSize size, XImage image, XColor? dotColour)
    {
        ImageDrawer.DrawImage(gfx, xPt, yPt, size, image);
        PawnBorderDrawer.DrawPawnBorder(gfx, xPt, yPt, size);

        if (!dotColour.HasValue)
        {
            return;
        }
        
        const int dotWidthMm = 5;
        var dotWidthPt = new XUnit(dotWidthMm, XGraphicsUnit.Millimeter).Point;
            
        var (_, heightPt) = size.GetPawnSize();
            
        var dotxPt = xPt + dotWidthPt / 3;
        var dotyPt = yPt + heightPt - 2 * dotWidthPt;
            
        gfx.DrawEllipse(new XSolidBrush(dotColour.Value), dotxPt, dotyPt, dotWidthPt, dotWidthPt);
    }
}