using Markdig.Syntax.Inlines;

namespace Markdig.Avalonia.Renderers.Inlines;

/// <summary>
/// An Avalonia renderer for <see cref="LiteralInline"/>.
/// </summary>
/// <seealso cref="LiteralInline"/>
public class LiteralInlineRenderer : AvaloniaObjectRenderer<LiteralInline>
{
    protected override void Write(AvaloniaRenderer renderer, LiteralInline obj)
    {
        if (obj.Content.IsEmpty)
        {
            return;
        }

        renderer.WriteText(ref obj.Content);
    }
}
