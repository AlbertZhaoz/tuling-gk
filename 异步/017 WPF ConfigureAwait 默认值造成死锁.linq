<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{

}

// You can define other methods, fields, classes and namespaces here
private void Button_Click(object sender, object e)
{
	// 当前主线程等待子线程结果
	// 子线程等待回到主线程，就造成了死锁
	var result = HeavyJobAsync().Result;
}


async Task<int> HeavyJobAsync()
{
	// 这边默认是 ConfigureAwait(true) 等待回到主线程
	await Task.Delay(2000);
	
	// 不会造成死锁就是不等待回到主线程上
	await Task.Delay(2000).ConfigureAwait(false);
	return 10;
}
