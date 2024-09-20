using System.Windows;
using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfBehaviors;

public class BorderMouseEnterBehavior : Behavior<Border>
{
    protected override void OnAttached()
    {
        AssociatedObject.MouseEnter += (object _, MouseEventArgs e) =>
        {
            AssociatedObject.Background = Brushes.AliceBlue;
        };
    }
}

public class ClearTextBoxTuBehaviors : Behavior<Button>
{
    public TextBox Target
    {
        get { return (TextBox)GetValue(TargetProperty); }
        set { SetValue(TargetProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TargetProperty =
        DependencyProperty.Register("Target", typeof(TextBox), typeof(ClearTextBoxTuBehaviors), new PropertyMetadata(null));



    protected override void OnAttached()
    {
        AssociatedObject.Click += (object _, RoutedEventArgs e) =>
        {
            Target?.Clear();
        };
    }
}

public class MouseWheel4FontSizeBehavior : Behavior<TextBox>
{
    protected override void OnAttached()
    {
        AssociatedObject.MouseWheel += (object _, MouseWheelEventArgs e) =>
        {

            if (e.Delta > 0)
            {
                AssociatedObject.FontSize += 1;
            }
            else
            {
                AssociatedObject.FontSize -= 1;
            }
        };
    }
}