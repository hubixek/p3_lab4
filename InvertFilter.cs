namespace ImageFilters;

public class InvertFilter : PixelFilter
{
    public override Color Transform(Color c)
    {
        c.R = 1 - c.R;
        c.G = 1 - c.G;
        c.B= 1 - c.B;
        return c;
    }
}