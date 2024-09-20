<Query Kind="Program" />

void Main()
{
	// 点一杯椰奶波波加上芋圆和珍珠
	var yeNaiBoBo = new YeNaiBoBo();
	var yuYuan = new YuYuan();
	var zhenZhu = new ZhenZhu();
	
	yuYuan.SetComponent(yeNaiBoBo);
	zhenZhu.SetComponent(yuYuan);
	
	zhenZhu.Cost().Dump();
	
}

// You can define other methods, fields, classes and namespaces here

public abstract class MilkTea{
	public abstract double Cost();
}

public abstract class Decorator:MilkTea{
	private MilkTea milkTea;
	
	public void SetComponent(MilkTea milkTea){
		this.milkTea = milkTea;
	}

	public override double Cost()
	{
		return milkTea.Cost();
	}
}

public class YuYuan:Decorator{
	private double price = 1;

	public override double Cost()
	{
		$"YuYuan 的价格为{price}".Dump();
		return base.Cost()+price;
	}
}

public class ZhenZhu : Decorator
{
	private double price = 2;

	public override double Cost()
	{
		$"ZhenZhu 的价格为{price}".Dump();
		return base.Cost() + price;
	}
}

public class YeNaiBoBo : MilkTea
{
	private double price = 10;
	
	public override double Cost()
	{
		$"YeNaiBoBo 的价格为{price}".Dump();
		return this.price;
	}
}

public class WuLongXueDing : MilkTea
{
	private double price = 15;
	
	public override double Cost()
	{
		$"WuLongXueDing 的价格为{price}".Dump();
		return this.price;
	}
}