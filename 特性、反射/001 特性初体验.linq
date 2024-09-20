<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var employee = new Employee(){
		Id = new Guid(),
		FirstName = "Albert",
		LastName = "Zhao",
		Age = 18,
		DateOfBirth = DateTime.Now,
		Skills = new List<string>(){"CSharp","Java","Go","Python"}
	};
	
	JsonConvert.SerializeObject(employee).Dump();
}

class Employee{
    [JsonIgnore]
	public Guid Id { get; set; }
	public string FirstName {get;set;}
	public string LastName { get; set; }
	public int Age { get; set; }
	[JsonProperty("Birth")]
	public DateTime DateOfBirth { get; set; }
	public List<string> Skills{get;set;}
}
