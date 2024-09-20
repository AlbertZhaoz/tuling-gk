<Query Kind="Program" />

void Main()
{
	var employee = new Employee()
	{
		Id = new Guid(),
		FirstName = "Albert",
		LastName = "Zhao",
		Age = 18,
		DateOfBirth = DateTime.Now,
		Skills = new List<string>() { "CSharp", "Java", "Go", "Python" }
	};
	
	SerializeObject(employee).Dump();
}

string SerializeObject(object obj)
{
	var result =
	obj.GetType().GetProperties()
	.Where(o =>
	{
		var attr = o.GetCustomAttribute<JsonIgnoreAttribute>();
		if (attr != null)
		{
			return false;
		}
		return true;
	})
	.Select(o => {
	
		var attr = o.GetCustomAttribute<JsonPropertyAttribute>();

		if (attr is not null)
			return new {Key=attr.SubName,Value=o.GetValue(obj)};
		else
			return new {Key=o.Name,Value=o.GetValue(obj)};
	});
	
	return string.Join(Environment.NewLine,result);
	
}

[AttributeUsage(AttributeTargets.Property)]
class JsonIgnoreAttribute:Attribute{
	
}

[AttributeUsage(AttributeTargets.Property)]
class JsonPropertyAttribute:Attribute{
	public string SubName { get; set; }
	
	public JsonPropertyAttribute(string subName)
	{
		SubName = subName;
	}
}

class Employee
{
	[JsonIgnore]
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
	[JsonProperty("Birth")]
	public DateTime DateOfBirth { get; set; }
	public List<string> Skills { get; set; }
}
