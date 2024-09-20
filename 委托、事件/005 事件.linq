<Query Kind="Program" />

//  1. event 
event Action<int> NotifyEvent; 

void Main()
{
	NotifyEvent += Notify;
	
	NotifyEvent?.Invoke(3);
}

void Notify(int num){
	num.Dump();
}

