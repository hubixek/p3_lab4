using System.Text;

namespace ImageFilters;

public abstract class ImageBase : IImage
{
    public int Width { get; }
    public int Height { get; }
    protected Color[,] _pixels;

    public ImageBase(int width, int height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), width, "Width and height must be greater than zero");
        }
        Width = width;
        Height = height;
        _pixels = new Color[width, height];
    }

    public Color this[int x, int y]
    {
        get
        {
            CheckBounds(x, y);
            return _pixels[x, y];
        }
        set
        {
            CheckBounds(x, y);
            _pixels[x, y] = value;
        }
    }

    private void CheckBounds(int x, int y)
    {
        if (x < 0 || x >= Width)
            throw new ArgumentOutOfRangeException(nameof(x), x, $"X must be in [0, {Width - 1}]");
        if (y < 0 || y >= Height)
            throw new ArgumentOutOfRangeException(nameof(y), y, $"Y must be in [0, {Height - 1}]");
    }
    public abstract ImageBase CreateEmpty(int width, int height);

    public virtual Color GetClamped(int x, int y)
    {
        if (x < 0)
        {
            x = 0;
        }

        if (y < 0)
        {
            y = 0;
        }

        if (x >= Width)
        {
            x = Width - 1;
        }

        if (y >= Height)
        {
            y = Height - 1;
        }
        return _pixels[x, y];
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine("P3");
        sb.AppendLine($"{Width} {Height}");
        sb.AppendLine("255");
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                sb.Append($"{_pixels[x, y]} ");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
    