namespace ImageFilters;

public interface IFilter
{
    ImageBase Apply(ImageBase source);
    
}