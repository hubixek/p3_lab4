namespace ImageFilters;

public class MatrixFilter : IFilter
{
    private readonly float[,] _kernel;
    private readonly float _divisor;

    public MatrixFilter(float[,] kernel, float divisor = 1.0f)
    {
        int size = kernel.GetLength(0);

        if (size != kernel.GetLength(1))
        {
            throw new ArgumentException("Kernel must be square", nameof(kernel));
        }
        if (size % 2 == 0)
        {
            throw new ArgumentException("Kernel size must be odd", nameof(kernel));
        }
        if (divisor == 0)
        {
            throw new ArgumentException("Divisor cannot be zero", nameof(divisor));
        }

        _kernel = (float[,])kernel.Clone();
        _divisor = divisor;
    }

    public ImageBase Apply(ImageBase source)
    {
        ImageBase result = source.CreateEmpty(source.Width, source.Height);
        int size = _kernel.GetLength(0);
        int r = size / 2;

        for (int y = 0; y < source.Height; y++)
        {
            for (int x = 0; x < source.Width; x++)
            {
                Color sum = new Color(0, 0, 0);
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        sum = sum + _kernel[i, j] * source.GetClamped(x + i - r, y + j - r);
                    }
                }
                result[x, y] = (sum / _divisor).Clamped();
            }
        }
        return result;
    }

    public static MatrixFilter BoxBlur()
    {
        return new MatrixFilter(new float[,]
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        }, 9);
    }

    public static MatrixFilter Sharpen()
    {
        return new MatrixFilter(new float[,]
        {
            {  0, -1,  0 },
            { -1,  5, -1 },
            {  0, -1,  0 }
        });
    }

    public static MatrixFilter EdgeDetect()
    {
        return new MatrixFilter(new float[,]
        {
            { -1, -1, -1 },
            { -1,  8, -1 },
            { -1, -1, -1 }
        });
    }
}