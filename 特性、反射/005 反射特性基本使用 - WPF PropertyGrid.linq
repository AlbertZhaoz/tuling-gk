<Query Kind="Program">
  <NuGetReference>Bogus</NuGetReference>
  <NuGetReference>Extended.Wpf.Toolkit</NuGetReference>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>Bogus</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.ComponentModel.DataAnnotations</Namespace>
  <Namespace>Xceed.Wpf.Toolkit.PropertyGrid.Attributes</Namespace>
</Query>

void Main()
{
	var faker = new Faker<Employee>()
			.RuleFor(e => e.Id, f => f.Random.Guid())
			.RuleFor(e => e.Gender, f => f.PickRandom<Gender>())
			.RuleFor(e => e.FirstName, (f, e) => f.Name.FirstName(e.Gender == Gender.男 ? Bogus.DataSets.Name.Gender.Male : Bogus.DataSets.Name.Gender.Female))
			.RuleFor(e => e.LastName, f => f.Name.LastName())
			.RuleFor(e => e.Email, f => f.Internet.Email())
			.RuleFor(e => e.Age, f => f.Random.Number(18, 65))
			.RuleFor(e => e.DateOfBirth, f => f.Date.Past(30))
			.RuleFor(e => e.Skills, f => f.Random.ListItems(new List<string> { "C#", "Java", "Go", "Python","Js"}, 3));

	var employee = faker.Generate();
	
	var pg = new PropertyGrid();
	pg.SelectedObject = employee;
	pg.Dump();
}

class Employee
{
	[Browsable(false)]
	public Guid Id { get; set; }
	public Gender Gender {get;set;}
	[Category("Name")]
	public string FirstName { get; set; }
	[Category("Name")]
	public string LastName { get; set; }
	public string Email {get;set;}
	[Range(0,100)]
	public int Age { get; set; }
	public DateTime DateOfBirth { get; set; }
	public List<string> Skills { get; set; }
}

enum Gender{
	男,
	女
}

