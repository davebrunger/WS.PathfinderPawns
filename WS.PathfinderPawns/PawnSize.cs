namespace WS.PathfinderPawns;

public enum PawnSize
{
    Small,
    Medium,
    Large,
    Huge
}

public static class PawnSizeExtensions
{
    private static readonly (double WidthPt, double HeightPt) SmallPawnSize =
    (
        new XUnit(21, XGraphicsUnit.Millimeter).Point,
        new XUnit(29, XGraphicsUnit.Millimeter).Point
    );

    private static readonly (double WidthPt, double HeightPt) MediumPawnSize =
    (
        new XUnit(29, XGraphicsUnit.Millimeter).Point,
        new XUnit(49, XGraphicsUnit.Millimeter).Point
    );

    private static readonly (double WidthPt, double HeightPt) LargePawnSize =
    (
        new XUnit(49, XGraphicsUnit.Millimeter).Point,
        new XUnit(63, XGraphicsUnit.Millimeter).Point
    );

    private static readonly (double WidthPt, double HeightPt) HugePawnSize =
    (
        new XUnit(76, XGraphicsUnit.Millimeter).Point,
        new XUnit(99, XGraphicsUnit.Millimeter).Point
    );

    public static (double WidthPt, double HeightPt) GetPawnSize(this PawnSize size)
    {
        return size switch
        {
            PawnSize.Small => SmallPawnSize,
            PawnSize.Medium => MediumPawnSize,
            PawnSize.Large => LargePawnSize,
            PawnSize.Huge => HugePawnSize,
            _ => throw new ArgumentOutOfRangeException(nameof(size))
        };
    }
}