<Query Kind="Program" />

delegate void PrintDelegate();

void Main()
{
	var printDelegate = new PrintDelegate(Print1);
	printDelegate += Print2;
	printDelegate -= Print1;
	
	printDelegate();
}

void Print1(){
	"Print1".Dump();
}

void Print2(){
	"Print2".Dump();
}
