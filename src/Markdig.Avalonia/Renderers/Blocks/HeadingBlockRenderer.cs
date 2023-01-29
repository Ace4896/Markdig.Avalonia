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
        var headingSpan = new Span();

        switch (obj.Level)
        {
            case 1:
                headingSpan.Classes.Add(StyleClasses.H1);
                break;
            case 2:
                headingSpan.Classes.Add(StyleClasses.H2);
                break;
            case 3:
                headingSpan.Classes.Add(StyleClasses.H3);
                break;
            case 4:
                headingSpan.Classes.Add(StyleClasses.H4);
                break;
            case 5:
                headingSpan.Classes.Add(StyleClasses.H5);
                break;
            case 6:
                headingSpan.Classes.Add(StyleClasses.H6);
                break;
        }

        renderer.PushBlockForRendering(headingSpan);
        renderer.WriteLeafBlockInlines(obj);
        renderer.CompleteCurrentBlock();
    }
}
