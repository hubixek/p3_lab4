namespace ImageFilters;

public class RectImage : ImageBase
{
    public RectImage(int width, int height) : base(width, height)
    {
    }

    public RectImage(int width, int height, Color fill)
        : this(width, height)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                this[x, y] = fill;
            }
        }
    }

    public override ImageBase CreateEmpty(int width, int height) => new RectImage(width, height);
}