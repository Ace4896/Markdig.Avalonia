using Avalonia.Controls.Documents;
using Avalonia.Media;
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
        var span = new Span();

        var oldFontStyle = renderer._currentFontStyle;
        var oldFontWeight = renderer._currentFontWeight;

        switch (obj.DelimiterChar)
        {
            case '*':
            case '_':
                switch (obj.DelimiterCount)
                {
                    case 1:
                        renderer._currentFontStyle = FontStyle.Italic;
                        break;

                    case 2:
                        renderer._currentFontWeight = FontWeight.Bold;
                        break;
                }

                break;
        }

        span.FontStyle = renderer._currentFontStyle;
        span.FontWeight = renderer._currentFontWeight;

        renderer.PushBlockForRendering(span);
        renderer.WriteChildren(obj);
        renderer.CompleteCurrentInline();

        renderer._currentFontStyle = oldFontStyle;
        renderer._currentFontWeight = oldFontWeight;
    }
}
