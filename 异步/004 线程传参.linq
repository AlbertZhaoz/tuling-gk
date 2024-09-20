<Query Kind="Program" />

void Main()
{
	var thread = new Thread(obj =>
	{
		TestThreadParam((int)obj);
	})
	{
		IsBackground = false,
		Priority = ThreadPriority.Normal
	};
	
	thread.Start(2);
}

// You can define other methods, fields, classes and namespaces here
void TestThreadParam(int num){
	(num*num).Dump();
}