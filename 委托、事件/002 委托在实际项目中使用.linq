<Query Kind="Program" />

delegate void Callback();

void Main()
{
	HeavyJob(CallbackImp2);
}

void HeavyJob(Callback callBack){
	Thread.Sleep(1);
	
	callBack?.Invoke();
}

void CallbackImp1(){
	"Job1 Done".Dump();
}

void CallbackImp2()
{
	"Job2 Done".Dump();
}


