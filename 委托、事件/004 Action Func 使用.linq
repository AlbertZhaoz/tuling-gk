<Query Kind="Program" />

// Action Func
//Action Callback;

void Main()
{
	HeavyJob(CallbackImp1);
	HeavyJonInput(CallbackInput1);
	
	HeavyJobFunc(CallbackFuncInput);
}

void HeavyJobFunc(Func<int,int,bool> CallbackFunc){
	var result = CallbackFunc?.Invoke(1,2);
	result.Dump();
}


bool CallbackFuncInput(int num1,int num2){
	if(num1 == num2){
		return true;
	}
	else{
		return false;
	}
}

void HeavyJonInput(Action<int> CallbackInput){

	CallbackInput?.Invoke(3);
}

void CallbackInput1(int num){
	num.Dump();
}

void HeavyJob(Action callBack)
{
	Thread.Sleep(1);

	callBack?.Invoke();
}

void CallbackImp1()
{
	"Job1 Done".Dump();
}

void CallbackImp2()
{
	"Job2 Done".Dump();
}

