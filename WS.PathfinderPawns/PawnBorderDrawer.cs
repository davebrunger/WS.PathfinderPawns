namespace WS.PathfinderPawns;

public static class PawnBorderDrawer
{
    public static void DrawPawnBorder(XGraphics gfx, double xPt, double yPt, PawnSize size)
    {
        var (widthPt, heightPt) = size.GetPawnSize();
        var cornerRadiusPt = widthPt / 3;
        var cornerDiameterPt = cornerRadiusPt * 2;
    
        gfx.DrawLine(XPens.Red, xPt, yPt + heightPt, xPt + widthPt, yPt + heightPt);
        gfx.DrawLine(XPens.Red, xPt, yPt + heightPt, xPt, yPt + cornerRadiusPt);
        gfx.DrawLine(XPens.Red, xPt + widthPt, yPt + heightPt, xPt + widthPt, yPt + cornerRadiusPt);
        gfx.DrawLine(XPens.Red, xPt + cornerRadiusPt, yPt, xPt + widthPt - cornerRadiusPt, yPt);
        gfx.DrawArc(XPens.Red, new XRect(xPt, yPt, cornerDiameterPt, cornerDiameterPt), 180, 90);
        gfx.DrawArc(XPens.Red, new XRect(xPt + widthPt - cornerDiameterPt, yPt, cornerDiameterPt, cornerDiameterPt), 270, 90);
    }
}