namespace ImageFilters;

public class FilterPipeline : IFilter
{
    private readonly IFilter[] _filters;

    public FilterPipeline(params IFilter[] filters)
    {
        _filters = (IFilter[])filters.Clone();
    }

    public ImageBase Apply(ImageBase source)
    {
        ImageBase current = source.CreateEmpty(source.Width, source.Height);
        for (int y = 0; y < source.Height; y++)
        {
            for (int x = 0; x < source.Width; x++)
            {
                current[x, y] = source[x, y];
            }
        }

        foreach (IFilter filter in _filters)
        {
            current = filter.Apply(current);
        }
        return current;
    }

    public override string ToString()
    {
        string[] names = new string[_filters.Length];
        for (int i = 0; i < _filters.Length; i++)
        {
            names[i] = _filters[i].GetType().Name;
        }
        return string.Join(" -> ", names);
    }
}