<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{

}

// You can define other methods, fields, classes and namespaces here
private async void Button_Click(object sender, object e)
{
	// 当按钮点击后会阻塞当前线程
	// var result = HeavyJob();

	// 不阻塞当前 UI 线程
	Debug.WriteLine($"Thread Id:{Environment.CurrentManagedThreadId}");
	var result = await HeavyJobAsync();
	// 如果是 false，前后两个线程就会不一样，无法回到 UI 线程上
	//var result = await HeavyJobAsync().ConfigureAwait(false);
	Debug.WriteLine($"Thread Id:{Environment.CurrentManagedThreadId}");
}


async Task<int> HeavyJobAsync()
{
	await Task.Delay(2000);
	return 10;
}
