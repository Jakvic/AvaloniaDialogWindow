using ReactiveUI.Fody.Helpers;

namespace AvaloniaApplication1.ViewModels;

public class DialogViewModel : ViewModelBase
{
    [Reactive]
    public string Title { get; set; } = "DialogView Title";

    [Reactive]
    public string Content { get; set; } = string.Empty;
}