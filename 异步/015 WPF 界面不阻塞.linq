<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	
}

// You can define other methods, fields, classes and namespaces here
private async void Button_Click(object sender,object e){
    // 当按钮点击后会阻塞当前线程
	// var result = HeavyJob();
	
	// 不阻塞当前 UI 线程
	var result = await HeavyJobAsync();
}

int HeavyJob(){
	Thread.Sleep(2);
	return 10;
}

async Task<int> HeavyJobAsync()
{
	await Task.Delay(2000);
	return 10;
}
