<Query Kind="Statements">
  <NuGetReference>Nito.AsyncEx</NuGetReference>
  <Namespace>Nito.AsyncEx</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var mutex = new AsyncLock();
var cts = new CancellationTokenSource();
var st = Stopwatch.StartNew();
var tasks = Enumerable.Range(1,10).Select(e => HeavyJobAsync(e,mutex,cts.Token)).ToList();
var result = await Task.WhenAll(tasks);
string.Join(',',result).Dump();
st.ElapsedMilliseconds.Dump();


async Task<int> HeavyJobAsync(int x,AsyncLock mutex,CancellationToken token){
	using (await mutex.LockAsync(token))
	{
		await Task.Delay(300);
		
		return x*x;
	}
}