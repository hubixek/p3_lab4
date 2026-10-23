namespace ImageFilters;

public interface IImage
{ 
    int Height { get; }
    int Width { get; }
    Color this[int x, int y] { get; set; }
}