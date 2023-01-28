using Markdig.Syntax;

namespace Markdig.Avalonia.Renderers.Blocks;

/// <summary>
/// An Avalonia renderer for <see cref="ParagraphBlock"/>.
/// </summary>
/// <seealso cref="ParagraphBlock"/>
public class ParagraphBlockRenderer : AvaloniaObjectRenderer<ParagraphBlock>
{
    protected override void Write(AvaloniaRenderer renderer, ParagraphBlock obj)
    {
        throw new NotImplementedException();
    }
}
