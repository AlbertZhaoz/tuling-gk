<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var setter = Task.Run(() => {
	Thread.Sleep(2000);
	"Setter OK...".Dump();
});

var waiter = Task.Run(async () => {
	await setter;
	"Signal received....".Dump();
});


await Task.WhenAll(setter,waiter);

"All task completed!".Dump();