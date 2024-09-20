using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfBindingDemo;

public class Employee : INotifyPropertyChanged
{
    private int id;

    public int Id
    {
        get { return id; }
        set
        {
            id = value;

            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("Id"));
        }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;

            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
        }
    }

    private string score;

    public string Score
    {
        get { return score; }
        set
        {
            score = value;

            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs("Score"));
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}