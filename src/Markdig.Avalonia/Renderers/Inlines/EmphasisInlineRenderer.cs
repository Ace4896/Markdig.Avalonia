using Avalonia.Controls.Documents;
using Markdig.Syntax.Inlines;

namespace Markdig.Avalonia.Renderers.Inlines;

/// <summary>
/// An Avalonia renderer for <see cref="EmphasisInline"/>.
/// </summary>
/// <seealso cref="EmphasisInline"/>
internal class EmphasisInlineRenderer : AvaloniaObjectRenderer<EmphasisInline>
{
    protected override void Write(AvaloniaRenderer renderer, EmphasisInline obj)
    {
        Span span = obj.DelimiterChar switch
        {
            '*' or '_' => obj.DelimiterCount == 2 ? new Bold() : new Italic(),
            _ => new Span(),
        };

        renderer.PushSpanForRendering(span);
        renderer.WriteChildren(obj);
        renderer.CompleteCurrentSpan();
    }
}
