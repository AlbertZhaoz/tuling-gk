<Query Kind="Program">
  <NuGetReference>Bogus</NuGetReference>
  <NuGetReference>Extended.Wpf.Toolkit</NuGetReference>
  <Namespace>Bogus</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.ComponentModel.DataAnnotations</Namespace>
</Query>

void Main()
{
	var faker = new Faker<Employee>()
	.RuleFor(e => e.Id,f=>f.Random.Guid())
	.RuleFor(e => e.FirstName, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
	.RuleFor(e => e.LastName, f => f.Name.LastName())
	.RuleFor(e => e.Age, f => f.Random.Number(18, 65))
	.RuleFor(e => e.DateOfBirth, f => f.Date.Past(30))
	.RuleFor(e => e.Skills, f => f.Random.ListItems(new List<string> { "C#", "Java", "Go", "Python", "Js" }, 3));
	var employee = faker.Generate();
	//employee.Dump();
	
	var pg = new PropertyGrid();
	pg.SelectedObject = employee;
	pg.Dump();
	
}

class Employee
{
	[Browsable(false)]
	public Guid Id { get; set; }
	[Category("Name")]
	public string FirstName { get; set; }
	[Category("Name")]
	public string LastName { get; set; }
	public int Age { get; set; }
	public DateTime DateOfBirth { get; set; }
	public List<string> Skills { get; set; }
}

