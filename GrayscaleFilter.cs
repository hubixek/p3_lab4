namespace ImageFilters;

public class GrayscaleFilter : PixelFilter
{
    public override Color Transform(Color c)
    {
        float L = 0.299f * c.R + 0.587f * c.G + 0.114f * c.B;
        return new Color(L, L, L);
    }
}