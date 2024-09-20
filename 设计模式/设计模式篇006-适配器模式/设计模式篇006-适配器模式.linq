<Query Kind="Program" />

void Main()
{
	//var bestAwesomePerson = new UserInfo();
	var bestAwesomePerson = new UserInfoAdapter();
	bestAwesomePerson.GetUserName().Dump();
}

// You can define other methods, fields, classes and namespaces here
public interface IUserInfo
{
	string GetUserName();
	string GetHomeAddress();
	string GetJob();
}

public class UserInfo : IUserInfo
{
	public string GetUserName()
	{
		return "DotNet技术官";
	}
	
	public string GetHomeAddress()
	{
		return "China";
	}

	public string GetJob()
	{
		return "Software Engineer";
	}	
}

public interface IOuterUserInfo
{
	Dictionary<string,string> GetUserBasicInfo();
	Dictionary<string,string> GetHomeInfo();
	Dictionary<string,string> GetJobInfo();
}

public class OuterUserInfo : IOuterUserInfo
{
	public Dictionary<string, string> GetUserBasicInfo()
	{
		var dic = new Dictionary<string, string>();
		dic.Add("UserName", "张三");
		return dic;
	}
	
	public Dictionary<string, string> GetHomeInfo()
	{
		var dic = new Dictionary<string,string>();
		dic.Add("Home","China");
		return dic;
	}

	public Dictionary<string, string> GetJobInfo()
	{
		var dic = new Dictionary<string, string>();
		dic.Add("Job", "Software Engineer");
		return dic;
	}
}

public class UserInfoAdapter : OuterUserInfo, IUserInfo
{
	public string GetHomeAddress()
	{
		return base.GetHomeInfo()["Home"];
	}

	public string GetJob()
	{
		return base.GetJobInfo()["Job"];
	}

	public string GetUserName()
	{
		return base.GetUserBasicInfo()["UserName"];
	}
}