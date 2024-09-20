<Query Kind="Program" />

// 1. 声明一个委托
delegate void PrintDelegate();
delegate int InputDelegate(int num);

void Main()
{
	// 2. 使用委托，使用 new 关键字
	var printDelegate = new PrintDelegate(Print2);	
	
	// 3. 如何调用
	printDelegate();
	printDelegate.Invoke();
	
	var inputDelegate = new InputDelegate(Input1);
	var inputResult = inputDelegate(3);
	inputResult.Dump();
}

int Input1(int numInput){
	return numInput+1;
}

void Print()
{
	"Print".Dump();
}

void Print2()
{
	"Print2".Dump();
}

