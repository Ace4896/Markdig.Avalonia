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
        string? styleClass = obj.DelimiterChar switch
        {
            '*' or '_' => obj.DelimiterCount switch
            {
                1 => StyleClasses.Italics,
                2 => StyleClasses.Bold,
                _ => null,
            },
            _ => null,
        };

        if (styleClass != null)
        {
            renderer.AddStyleClass(styleClass);
        }

        renderer.PushBlockForRendering(new Span());
        renderer.SetStyleClasses();
        renderer.WriteChildren(obj);
        renderer.CompleteCurrentInline();

        if (styleClass != null)
        {
            renderer.RemoveStyleClass(styleClass);
        }
    }
}
