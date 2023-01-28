using Avalonia.Controls;
using Avalonia.Controls.Documents;
using System;

namespace Markdig.Avalonia.SampleApp.Views.Pages;

public partial class SandboxView : UserControl
{
    public SandboxView()
    {
        InitializeComponent();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        // Various Avalonia inlines which could be used for rendering the Markdown
        // Conversions are noted as Markdig Type -> Avalonia Type
        var inlineCollection = new InlineCollection();
        txtInlines.Inlines = inlineCollection;

        // LiteralInline -> Run
        // Runs can be added to Avalonia's inline collection as-is
        // Spans are used to group Avalonia inlines together, so I could return a Span at the top-level
        inlineCollection.AddRange(new[]
        {
            new Run("literal inline"),
            new Run("notice how there's no space between runs"),
        });

        // ParagraphBlock -> LineBreak x2
        // I tried making a custom ParagraphBreak, but I can't implement the internal abstract functions...
        inlineCollection.AddRange(new Inline[]
        {
            new LineBreak(),
            new LineBreak(),
            new Run("next paragraph begins here"),
            new LineBreak(),
            new LineBreak(),
            new Run("and another paragraph begins here"),
        });

        // EmphasisInline (**/__ Delimiter) -> Bold Span
        // The contents of this inline would be recursively rendered, since we might also have e.g. italics
        var boldSpan = new Bold();
        boldSpan.Inlines.Add(new Run("some bold text"));

        inlineCollection.AddRange(new Inline[]
        {
            new LineBreak(),
            new LineBreak(),
            boldSpan,
        });

        // EmphasisInline (*/_ Delimiter) -> Italic Span
        // Again, contents would be recursively rendered
        var italicsSpan = new Italic();
        italicsSpan.Inlines.Add(new Run("some italics text"));

        inlineCollection.AddRange(new Inline[]
        {
            new LineBreak(),
            new LineBreak(),
            italicsSpan,
        });

        var markdownPipeline = new MarkdownPipelineBuilder().Build();

        // As a test, a simple markdown document like this:
        //
        // some test text
        //
        // Should result in a ParagraphBlock -> LiteralInline("some test text")
        // And should be rendered to Span -> Run("some test text")
        //const string testText = "some test text";
        //Markdown.ToInlineCollection(testText, markdownPipeline);

        // More complex text now
        // There should be two paragraph blocks
        string twoParagraphs = @"first paragraph here

second paragraph here";
        txtInlines.Inlines = Markdown.ToInlineCollection(twoParagraphs, markdownPipeline);
    }
}