<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	var student = new Student(){
		Id =1,
		Age =24,
		Gender = Gender.男,
		Name = "John"
	};
	
	Serialize(student).Dump();
}

string Serialize(object obj){

	var result = obj.GetType().GetProperties()
	.Where(o => {
	 	var attr = o.GetCustomAttribute<BrowsableAttribute>();
		if(attr is not null) return attr.Browsable;
		
		return true;
	})
	.Select(o =>
	{
		var attr = o.GetCustomAttribute<ConverterAttribute>();
		if (attr is not null)
		{
			return new {Key = o.Name,Value =(object)((int)o.GetValue(obj)+attr.ConvertValue)};
		}

		return new { Key = o.Name, Value = o.GetValue(obj) };
	})
	.Select(o => $"{o.Key}:{o.Value}");

	return string.Join(Environment.NewLine,result);
}


class Student
{
	[Browsable(false)]
	public int Id { get; set; }
	public string Name { get; set; }
	[ConverterAttribute(1,Tag="123")]
	public int Age { get; set; }
	public Gender Gender { get; set; }
}

[AttributeUsage(AttributeTargets.Property)]
class ConverterAttribute:Attribute{
	public int ConvertValue { get; set; }
	public string Tag { get; set; }

	public ConverterAttribute(int v)
	{
		ConvertValue = v;
	}
}

enum Gender
{
	男,
	女
}