namespace ImageFilters;

public abstract class PixelFilter : IFilter
{
    public abstract Color Transform(Color c);

    public ImageBase Apply(ImageBase source)
    {
        ImageBase result = source.CreateEmpty(source.Width, source.Height);
        for (int y = 0; y < source.Height; y++)
        {
            for (int x = 0; x < source.Width; x++)
            {
                result[x, y] = Transform(source[x, y]);
            }
        }
        return result;
    }

}