using Avalonia.Controls.Documents;
using Markdig.Avalonia.Styles;
using Markdig.Syntax;

namespace Markdig.Avalonia.Renderers.Blocks;

/// <summary>
/// An Avalonia renderer for <see cref="HeadingBlock"/>.
/// </summary>
/// <seealso cref="HeadingBlock"/>
public class HeadingBlockRenderer : AvaloniaObjectRenderer<HeadingBlock>
{
    protected override void Write(AvaloniaRenderer renderer, HeadingBlock obj)
    {
        string? addedStyleClass = obj.Level switch
        {
            1 => StyleClasses.H1,
            2 => StyleClasses.H2,
            3 => StyleClasses.H3,
            4 => StyleClasses.H4,
            5 => StyleClasses.H5,
            6 => StyleClasses.H6,
            _ => null,
        };

        if (addedStyleClass != null)
        {
            renderer.AddStyleClass(addedStyleClass);
        }

        renderer.PushBlockForRendering(new Span());
        renderer.SetStyleClasses();
        renderer.WriteLeafBlockInlines(obj);
        renderer.CompleteCurrentBlock();

        if (addedStyleClass != null)
        {
            renderer.RemoveStyleClass(addedStyleClass);
        }
    }
}
