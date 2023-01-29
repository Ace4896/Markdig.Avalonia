namespace Markdig.Avalonia.SampleApp.ViewModels.Pages;

/// <summary>
/// ViewModel for the editor page.
/// </summary>
public class EditorViewModel : ViewModelBase
{
    private string _currentMarkdownText = string.Empty;
    public string CurrentMarkdownText
    {
        get => _currentMarkdownText;
        set => SetProperty(ref _currentMarkdownText, value);
    }
}
