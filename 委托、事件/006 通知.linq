<Query Kind="Program" />

void Main()
{
	var demoViewModel = new DemoViewModel();
	demoViewModel.NotifyPropertyChanged += () => {
		"Value Changed".Dump();
	};
	demoViewModel.MyProperty = 66;
	
	//demoViewModel.NotifyPropertyChanged?.Invoke();
}


public delegate void EventHandler(object? sender, EventArgs e);

class DemoViewModel{
	public event Action NotifyPropertyChanged;

	int _myField;
	
	public int MyProperty
	{
		get { return _myField; }
		set { _myField = value;
		
			NotifyPropertyChanged?.Invoke();
		}
	}
	
}

