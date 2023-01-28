using Markdig.Avalonia.SampleApp.Models;
using Markdig.Avalonia.SampleApp.ViewModels.Pages;
using System;

namespace Markdig.Avalonia.SampleApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public PageType[] Pages { get; } = Enum.GetValues<PageType>();

    private PageType _currentPage;
    public PageType CurrentPage
    {
        get => _currentPage;
        set
        {
            if (SetProperty(ref _currentPage, value))
            {
                CurrentViewModel = GetViewModelForPage(value);
            }
        }
    }

    private ViewModelBase? _currentViewModel;
    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        private set => SetProperty(ref _currentViewModel, value);
    }

    public MainWindowViewModel()
    {
        CurrentPage = PageType.Sandbox;
        CurrentViewModel = GetViewModelForPage(CurrentPage);
    }

    private static ViewModelBase? GetViewModelForPage(PageType pageType) => pageType switch
    {
        PageType.Sandbox => new SandboxViewModel(),
        _ => null,
    };
}
