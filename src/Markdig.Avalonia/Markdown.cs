using Avalonia.Controls.Documents;
using Markdig.Avalonia.Renderers;

namespace Markdig.Avalonia;

public static partial class Markdown
{
    // TODO: Preserve the renderer as well? Though it won't have a huge effect I think...
    public static InlineCollection ToInlineCollection(string markdown, MarkdownPipeline? pipeline = null)
    {
        pipeline ??= new MarkdownPipelineBuilder().Build();

        var renderer = new AvaloniaRenderer();
        pipeline.Setup(renderer);

        var parsedDocument = Markdig.Markdown.Parse(markdown);
        var renderedDocument = (InlineCollection)renderer.Render(parsedDocument);

        return renderedDocument;
    }
}
