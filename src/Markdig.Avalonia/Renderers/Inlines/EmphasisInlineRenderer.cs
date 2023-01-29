using Avalonia.Controls.Documents;
using Avalonia.Media;
using Markdig.Avalonia.Styles;
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
        var emphasisInlineSpan = new Span();

        switch (obj.DelimiterChar)
        {
            case '*':
            case '_':
                switch (obj.DelimiterCount)
                {
                    case 1:
                        emphasisInlineSpan.Classes.Add(StyleClasses.Italics);
                        break;
                    case 2:
                        emphasisInlineSpan.Classes.Add(StyleClasses.Bold);
                        break;
                }

                break;
        }

        renderer.PushBlockForRendering(emphasisInlineSpan);
        renderer.WriteChildren(obj);
        renderer.CompleteCurrentInline();
    }
}
