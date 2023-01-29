using Avalonia.Controls.Documents;
using Markdig.Avalonia.Renderers;

namespace Markdig.Avalonia;

public static partial class Markdown
{
    public static InlineCollection ToInlineCollection(string markdown, MarkdownPipeline? pipeline = null, AvaloniaRenderer? renderer = null)
    {
        pipeline ??= new MarkdownPipelineBuilder().Build();
        renderer ??= new AvaloniaRenderer();
        pipeline.Setup(renderer);

        var parsedDocument = Markdig.Markdown.Parse(markdown);
        var renderedDocument = (InlineCollection)renderer.Render(parsedDocument);

        return renderedDocument;
    }
}
