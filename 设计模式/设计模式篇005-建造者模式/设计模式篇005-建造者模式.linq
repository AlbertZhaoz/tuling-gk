<Query Kind="Program" />

void Main()
{
	var director = new Director();
	var sanxingBuilder = new SanxingBuilder();
	director.InitBuild(sanxingBuilder);
	var dellBuilder = new DellBuilder();
	director.InitBuild(dellBuilder);
}

// You can define other methods, fields, classes and namespaces here
public class Director{
	public void InitBuild(Builder builder){
		builder.BuildMainBord().BuildCpu().BuildMemory().BuildScreen();
	}
}

public class Computer{
	public string Cpu {get;set;}
	public string Memory {get;set;}
	public string Mainbord {get;set;}
	public string Screen {get;set;}
}

public abstract class Builder{
	public abstract Builder BuildCpu();
	public abstract Builder BuildMemory();
	public abstract Builder BuildMainBord();
	public abstract Builder BuildScreen();
	public abstract Computer GetComputer();
}

public class DellBuilder : Builder
{
	private Computer _computer = new Computer();

	public override Builder BuildCpu()
	{
		_computer.Cpu = "Dell Cpu";
		_computer.Cpu.Dump();
		return this;
	}

	public override Builder BuildMainBord()
	{
		_computer.Mainbord = "Dell MainBord";
		_computer.Mainbord.Dump();
		return this;
	}

	public override Builder BuildMemory()
	{
		_computer.Memory = "Dell Memory";
		_computer.Memory.Dump();
		return this;
	}

	public override Builder BuildScreen()
	{
		_computer.Screen = "Dell Screen";
		_computer.Screen.Dump();
		return this;
	}

	public override Computer GetComputer()
	{
		return this._computer;
	}
}

public class SanxingBuilder : Builder
{
	private Computer _computer = new Computer();

	public override Builder BuildCpu()
	{
		this._computer.Cpu = "SanxingCpu";
		this._computer.Cpu.Dump();
		return this;
	}

	public override Builder BuildMainBord()
	{
		_computer.Mainbord = "Sanxing MainBord";
		_computer.Mainbord.Dump();
		return this;
	}

	public override Builder BuildMemory()
	{
		_computer.Memory = "Sanxing Memory";
		_computer.Memory.Dump();
		return this;
	}

	public override Builder BuildScreen()
	{
		_computer.Screen = "Sanxing Screen";
		_computer.Screen.Dump();
		return this;
	}

	public override Computer GetComputer()
	{
		return this._computer;
	}
}