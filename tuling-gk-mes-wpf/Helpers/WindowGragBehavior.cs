using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace WpfTulingGkMes.Helpers;

public class WindowGragBehavior:Behavior<Window>
{
    protected override void OnAttached()
    {
        AssociatedObject.MouseLeftButtonDown += (s, _) => ((Window)s).DragMove();
    }
}