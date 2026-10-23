namespace ImageFilters;

public class ThresholdFilter : PixelFilter
{
    float Threshold;
    public ThresholdFilter(float threshold)
    {
        Threshold =  threshold;
    }
    public override Color Transform(Color c)
    {
        float L = 0.299f * c.R + 0.587f * c.G + 0.114f * c.B;
        if (L >= Threshold)
        {
            c.G = 1;
            c.B = 1;
            c.R = 1;
            return c;
        }
        c.G = 0;
        c.B = 0;
        c.R = 0;
        return c;
    }
}