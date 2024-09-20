<Query Kind="Statements">
  <Namespace>System.Net.Http</Namespace>
</Query>


using var cts = new CancellationTokenSource(3000);

var sw = Stopwatch.StartNew();
try
{
	var client = new HttpClient();
	var result = await client.GetStringAsync("http://localhost:5000",
	cts.Token);
	result.Dump();
}
catch (Exception ex)
{
	ex.Dump();
}
