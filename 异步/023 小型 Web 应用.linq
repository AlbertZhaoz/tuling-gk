<Query Kind="Statements">
  <Namespace>Microsoft.AspNetCore.Builder</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

var app = WebApplication.Create();

app.MapGet("/", async() =>
{
	await Task.Delay(5000);

	return "Hello Albert";
});

app.Run();