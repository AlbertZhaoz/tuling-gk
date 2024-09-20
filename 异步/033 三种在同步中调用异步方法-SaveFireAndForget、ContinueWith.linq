<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>





class MyDataModel{
	public List<int>? Data {get;private set;}
	public bool IsDataLoaded { get; set; } = false;
	
	public MyDataModel()
	{
		// 方式一：安全式一发即忘
		SafeFireAndForget(LoadDataAsync(),() => {
			"OnCompleted".Dump();
		}, e =>
		{
			$"OnError...{e.Message}".Dump();
		});

		LoadDataAsync().Await(() =>
		{
			"OnCompleted".Dump();
		}, e =>
		{
			$"OnError...{e.Message}".Dump();
		});
		// 方式二：ContinueWith
		LoadDataAsync().ContinueWith(OnDataLoaded);
	}
	
	bool OnDataLoaded(Task task){
		if(task.IsFaulted){
			task.Exception.Dump();
		}
		
		return IsDataLoaded = true;
	}

	static async void SafeFireAndForget(Task task,Action? onCompleted = null,Action<Exception>? onError = null){
		try
		{	        
			await task;
			onCompleted?.Invoke();
		}
		catch (Exception ex)
		{
			onError?.Invoke(ex);
		}
	}
	
	async Task LoadDataAsync(){
		await Task.Delay(1000);
		
		Data = Enumerable.Range(1,10).ToList();
	}
}

static class TaskExtensions{
	public static async void Await(this Task task,Action? onCompleted = null,Action<Exception>? onError = null){
		try
		{	        
			await task;
			onCompleted?.Invoke();
		}
		catch (Exception ex)
		{
			onError?.Invoke(ex);
		}
	}
}