namespace WS.PathfinderPawns;

public static class PawnDrawer
{
    public static void DrawPawn(XGraphics gfx, double xPt, double yPt, PawnSize size, XImage image)
    {
        ImageDrawer.DrawImage(gfx, xPt, yPt, size, image);
        PawnBorderDrawer.DrawPawnBorder(gfx, xPt, yPt, size);
    }
}