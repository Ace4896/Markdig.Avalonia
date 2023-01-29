using Avalonia.Media;

namespace Markdig.Avalonia.Renderers;

/// <summary>
/// Represents the formatting that should be used by a span.
/// </summary>
internal struct FontFormatting
{
    public FontStyle FontStyle { get; set; }
    public FontWeight FontWeight { get; set; }

    public FontFormatting()
    {
        FontStyle = FontStyle.Normal;
        FontWeight = FontWeight.Normal;
    }
}
