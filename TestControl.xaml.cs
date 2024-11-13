using System.ComponentModel;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace xBindControlInResTemplateRepro;
public sealed partial class TestControl : UserControl
{
    public TestControl()
    {
        this.InitializeComponent();
    }

    public static string ToTestFunc(string testText)
    {
        return testText;
    }
}

public class Decoy : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string _value;
    public string Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
            }
        }
    }

    public string Result => Value;
}

//public class Decoy : DependencyObject
//{
//    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
//        nameof(Value),
//        typeof(string),
//        typeof(Decoy),
//        new PropertyMetadata(string.Empty));

//    public string Value
//    {
//        get => (string)GetValue(ValueProperty);
//        set => SetValue(ValueProperty, value);
//    }
//}