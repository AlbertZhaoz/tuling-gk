using System.Windows;
using System.Windows.Controls;

namespace WpfAppForType.Uc;

public class FeedbackButton : Button
{
    public Type MessageWindow { get; set; }

    protected override void OnClick()
    {
        base.OnClick();
        var window = Activator.CreateInstance(this.MessageWindow) as Window;
        window?.Show();
    }
}