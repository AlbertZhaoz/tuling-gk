using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfToolKitDemo.ViewModels
{
    public class ViewModelBaseDemo : INotifyPropertyChanged
    {
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

    public class MainWindowDemo : ViewModelBaseDemo
    {
        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                age = value;

                if (age != value)
                {
                    OnPropertyChanged();
                }

            }
        }
    }

    // public class RelayCommand : ICommand
    // {
    //     public bool CanExecute(object? parameter)
    //     {
    //         
    //     }
    //
    //     public void Execute(object? parameter)
    //     {
    //         
    //     }
    //
    //     public event EventHandler? CanExecuteChanged;
    // }
}
