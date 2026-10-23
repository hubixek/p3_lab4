namespace ImageFilters;

public class BrightnessFilter : PixelFilter
{
    float Factor;

    public BrightnessFilter(float factor)
    {
        Factor =  factor;
    }
    public override Color Transform(Color c)
    {
        c.R = c.R * Factor;
        c.G = c.G * Factor;
        c.B = c.B * Factor;
        return c.Clamped();

    }
}