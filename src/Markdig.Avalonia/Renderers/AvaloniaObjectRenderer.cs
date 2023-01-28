using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace Markdig.Avalonia.Renderers;

/// <summary>
/// A base class that renders <see cref="Block"/> and <see cref="Inline"/> objects for Avalonia.
/// </summary>
public abstract class AvaloniaObjectRenderer<TObject> : MarkdownObjectRenderer<AvaloniaRenderer, TObject>
    where TObject : MarkdownObject
{
}
