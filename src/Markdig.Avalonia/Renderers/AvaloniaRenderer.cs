using Avalonia.Controls.Documents;
using Avalonia.Layout;
using Markdig.Avalonia.Renderers.Blocks;
using Markdig.Avalonia.Renderers.Inlines;
using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Syntax;

namespace Markdig.Avalonia.Renderers;

/// <summary>
/// Avalonia renderer for a <see cref="MarkdownObject"/>.
/// </summary>
public class AvaloniaRenderer : RendererBase
{
    private Stack<Span> _renderStack;
    private InlineCollection _renderedInlines;

    public AvaloniaRenderer()
    {
        _renderStack = new();
        _renderedInlines = new();

        LoadObjectRenderers();
    }

    public override object Render(MarkdownObject markdownObject)
    {
        _renderStack = new();
        _renderedInlines = new();

        Write(markdownObject);
        return _renderedInlines;
    }

    private void LoadObjectRenderers()
    {
        ObjectRenderers.AddRange(new IMarkdownObjectRenderer[]
        {
            // Default Block Renderers
            new ParagraphBlockRenderer(),

            // Default Inline Renderers
            new EmphasisInlineRenderer(),
            new LiteralInlineRenderer(),
        });
    }

    #region Stack Operations (Avalonia-side)

    public void PushBlockForRendering(Span span)
    {
        _renderStack.Push(span);
    }

    public void WriteRenderedInline(Inline inline)
    {
        _renderStack.Peek().Inlines.Add(inline);
    }

    public void CompleteCurrentInline()
    {
        var currentInline = _renderStack.Pop();
        _renderStack.Peek().Inlines.Add(currentInline);
    }

    public void CompleteCurrentBlock()
    {
        var currentSpan = _renderStack.Pop();

        // Add linebreaks between blocks
        if (_renderedInlines.Count > 0)
        {
            // TODO: Might be a more efficient way to add linebreaks between blocks...
            _renderedInlines.Add(new LineBreak());
            _renderedInlines.Add(new LineBreak());
        }

        _renderedInlines.Add(currentSpan);
    }

    #endregion

    #region Render Operations (Markdig-side)

    public void WriteLeafBlockInlines(LeafBlock leafBlock)
    {
        var inline = (Syntax.Inlines.Inline?)leafBlock.Inline;
        while (inline != null)
        {
            Write(inline);
            inline = inline?.NextSibling;
        }
    }

    public void WriteText(ref StringSlice slice)
    {
        if (slice.Start > slice.End)
        {
            return;
        }

        var renderedInline = new Run(slice.AsSpan().ToString());
        WriteRenderedInline(renderedInline);
    }

    #endregion
}
