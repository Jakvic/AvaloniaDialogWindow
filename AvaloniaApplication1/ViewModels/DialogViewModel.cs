using PropertyChanging;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels;

[ImplementPropertyChanging]
public class DialogViewModel
{
    public string Title { get; set; } = "DialogView Title";

    public string Content { get; set; } = string.Empty;
}