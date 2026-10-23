namespace ImageFilters;

public struct Color
{
    public float R { get; set; }
    public float G { get; set; }
    public float B { get; set; }
    
    

    public Color(float r, float g, float b)
    {
        R = r;
        G = g;
        B = b;
    }
    public static Color operator +(Color a, Color b) => new Color(a.R + b.R, a.G + b.G, a.B + b.B);
    public static Color operator *(Color a, float b) => new Color(a.R * b, a.G * b, a.B * b);
    public static Color operator *(float b,Color a) => new Color(a.R *b, a.G * b, a.B * b);
    public static Color operator /(Color a,float b) => new Color(a.R / b, a.G / b, a.B / b);

    public Color Clamped()
    {
        return new Color(Math.Clamp(R,0,1), Math.Clamp(G,0,1), Math.Clamp(B,0,1));
    }

    public override string ToString()
    {
        Color c = Clamped();
        return $"{Math.Round(c.R * 255)} {Math.Round(c.G * 255)} {Math.Round(c.B * 255)}";
    }
}