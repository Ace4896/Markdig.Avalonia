using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Markdig.Avalonia.Renderers;

namespace Markdig.Avalonia.Controls;

/// <summary>
/// A <see cref="SelectableTextBlock"/> capable of displaying Markdown.
/// </summary>
[TemplatePart("PART_SelectableTextBlock", typeof(SelectableTextBlock))]
public class MarkdownTextBlock : TemplatedControl
{
    private static readonly InlineCollection EmptyInlineCollection = new() { new Run("") };
    private readonly AvaloniaRenderer _avaloniaMarkdownRenderer = new();

    private SelectableTextBlock? _selectableTextBlock;

    private MarkdownPipeline _markdownPipeline = new MarkdownPipelineBuilder().Build();
    private string? _markdownText;

    /// <summary>
    /// Defines the <see cref="MarkdownPipeline"/> property.
    /// </summary>
    public static readonly DirectProperty<MarkdownTextBlock, MarkdownPipeline> MarkdownPipelineProperty =
        AvaloniaProperty.RegisterDirect<MarkdownTextBlock, MarkdownPipeline>(
            nameof(MarkdownPipeline),
            o => o.MarkdownPipeline,
            (o, v) => o.MarkdownPipeline = v
        );

    /// <summary>
    /// Defines the <see cref="MarkdownText"/> property.
    /// </summary>
    public static readonly DirectProperty<MarkdownTextBlock, string?> MarkdownTextProperty =
        AvaloniaProperty.RegisterDirect<MarkdownTextBlock, string?>(
            nameof(MarkdownText),
            o => o.MarkdownText,
            (o, v) => o.MarkdownText = v
        );

    /// <summary>
    /// Gets or sets the current <see cref="MarkdownPipeline"/> to use for rendering.
    /// </summary>
    public MarkdownPipeline MarkdownPipeline
    {
        get => _markdownPipeline;
        set => SetAndRaise(MarkdownPipelineProperty, ref _markdownPipeline, value);
    }

    /// <summary>
    /// Gets or sets the current Markdown text to be rendered.
    /// </summary>
    public string? MarkdownText
    {
        get => _markdownText;
        set => SetAndRaise(MarkdownTextProperty, ref _markdownText, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _selectableTextBlock = e.NameScope.Get<SelectableTextBlock>("PART_SelectableTextBlock");
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        switch (change.Property.Name)
        {
            case nameof(MarkdownPipeline):
                var newPipeline = change.GetNewValue<MarkdownPipeline>();
                newPipeline.Setup(_avaloniaMarkdownRenderer);

                RenderMarkdown(MarkdownText, newPipeline);
                break;

            case nameof(MarkdownText):
                var newText = change.GetNewValue<string?>();
                RenderMarkdown(newText, MarkdownPipeline);
                break;
        }
    }

    private void RenderMarkdown(string? text, MarkdownPipeline pipeline)
    {
        if (_selectableTextBlock == null)
        {
            return;
        }

        // NOTE: Clearing an inline collection doesn't seem to clear the displayed text
        // For now, need to workaround this by rendering an empty text run
        _selectableTextBlock.Inlines = string.IsNullOrEmpty(text)
            ? EmptyInlineCollection
            : Markdown.ToInlineCollection(text, pipeline, _avaloniaMarkdownRenderer);
    }
}
