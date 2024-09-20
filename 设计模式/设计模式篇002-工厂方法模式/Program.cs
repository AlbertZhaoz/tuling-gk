using 设计模式篇002_工厂方法模式.工厂方法设计模式;
using 设计模式篇002_工厂方法模式.简单工厂;

var yellowHuman = HumanFactorySimple.CreateHuman<YellowMan>();
yellowHuman.GetColor();
yellowHuman.Talk();
var blackHuman = HumanFactorySimple.CreateHuman<BlackMan>();
blackHuman.GetColor();
blackHuman.Talk();
var whiteHuman = HumanFactorySimple.CreateHuman<WhiteMan>();
whiteHuman.GetColor();
whiteHuman.Talk();

Console.WriteLine("===========");
var humanFactory = new HumanFactory();
var yellow = humanFactory.CreateHuman<YellowMan>();
yellow.GetColor();
yellow.Talk();


Console.WriteLine("延迟加载");
FactoryDelay factory = new FactoryDelay();
var yellowDelay = factory.GetHuman("Yellow");
yellowDelay.GetColor();
yellowDelay.Talk();