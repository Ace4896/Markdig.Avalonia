using Markdig.Renderers;
using Markdig.Syntax;

namespace Markdig.Avalonia.Renderers;

/// <summary>
/// Avalonia renderer for a <see cref="MarkdownObject"/>
/// </summary>
public class AvaloniaRenderer : RendererBase
{
    public override object Render(MarkdownObject markdownObject)
    {
        Write(markdownObject);
        return new object();    // stub
    }
}
