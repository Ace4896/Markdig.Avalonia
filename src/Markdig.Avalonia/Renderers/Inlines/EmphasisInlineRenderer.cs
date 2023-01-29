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
        var oldFontFormatting = renderer.CurrentFontFormatting;

        switch (obj.DelimiterChar)
        {
            case '*':
            case '_':
                switch (obj.DelimiterCount)
                {
                    case 1:
                        renderer.CurrentFontFormatting.FontStyle = FontStyle.Italic;
                        break;

                    case 2:
                        renderer.CurrentFontFormatting.FontWeight = FontWeight.Bold;
                        break;
                }

                break;
        }

        renderer.PushBlockForRendering(new Span());
        renderer.SetFontFormatting();
        renderer.WriteChildren(obj);
        renderer.CompleteCurrentInline();

        renderer.CurrentFontFormatting = oldFontFormatting;
    }
}
