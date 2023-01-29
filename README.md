# Markdig.Avalonia

An Avalonia renderer for [Markdig](https://github.com/xoofx/markdig).

It is currently a work-in-progress; these Markdown elements are implemented:

- **Blocks**
  - Paragraph
  - Headings
- **Inlines**
  - Literals
  - Emphasis (Bold, Italics)

No extensions are supported at the moment.

## Requirements

- .NET 6.0
- Avalonia 11

`Markdig.Avalonia` heavily relies on Avalonia 11's support for inlines, so Avalonia 0.10.x and below are not supported.

## Usage

**TODO**: Styling will be re-implemented as control themes, to make it easier to change the theme for individual controls

This library provides the `MarkdownTextBlock` control for Avalonia, which is derived from `SelectableTextBlock`. It can be imported from the `Markdig.Avalonia.Controls` namespace and used as follows:

```xaml
<UserControl xmlns:mdctrls="using:Markdig.Avalonia.Controls">
    <mdctrls:MarkdownTextBlock x:Name="txtMarkdownDisplay" MarkdownText="**Hello world!**" />
</UserControl>
```

![Hello World](./docs/usage-hello-world.png)

It can be used with Data Binding as well; given this ViewModel that implements `INotifyPropertyChanged`:

```csharp
public class MyViewModel : INotifyPropertyChanged
{
    private string _inputText = "**Hello world from MyViewModel!**";
    public string InputText
    {
        get => _inputText;
        set => SetProperty(ref _inputText, value);
    }
}
```

We can bind to `InputText` and also have the rendered Markdown update whenever the property changes:

```xaml
<UserControl xmlns:mdctrls="using:Markdig.Avalonia.Controls">
    <mdctrls:MarkdownTextBlock x:Name="txtMarkdownDisplay" MarkdownText="{Binding InputText}" />
</UserControl>
```

![Hello World (Binding)](./docs/usage-hello-world-binding.png)

### Customising Markdown Parsing

If you want to customise how the Markdown document is parsed (e.g. to add extensions), you can also set the `MarkdownPipeline` on the control as well. Just keep in mind that not all extensions are supported by the renderer.
